
-- Creación de las tablas
CREATE TABLE Usuario (
    id INT PRIMARY KEY,
    Apellidos VARCHAR(255) NOT NULL,
    DNI VARCHAR(20) UNIQUE NOT NULL,
    Es_admin BIT NOT NULL DEFAULT 0,
    Correo_electronico VARCHAR(255) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL
);

CREATE TABLE Admin (
    id INT PRIMARY KEY,
    FOREIGN KEY (id) REFERENCES Usuario(id) ON DELETE CASCADE
);

CREATE TABLE Socio (
    id INT PRIMARY KEY,
    Saldo INT CHECK (Saldo >= 0) DEFAULT 0,
    Estado VARCHAR(50) NOT NULL,
    FOREIGN KEY (id) REFERENCES Usuario(id) ON DELETE CASCADE
);

CREATE TABLE Membresia (
    Id INT PRIMARY KEY,
    Descripcion VARCHAR(255) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Precio FLOAT CHECK (Precio >= 0) NOT NULL
);

CREATE TABLE Monitor (
    id INT PRIMARY KEY,
    especialidad VARCHAR(255) NOT NULL,
    salario FLOAT CHECK (salario >= 0) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    FOREIGN KEY (id) REFERENCES Usuario(id) ON DELETE CASCADE
);

CREATE TABLE Categoria (
    id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
);

CREATE TABLE Actividad (
    id INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(255),
    precio FLOAT CHECK (precio >= 0) NOT NULL,
    id_categoria INT NOT NULL,
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id) ON DELETE CASCADE
);

CREATE TABLE Actividad_impartida (
    id_actividad INT,
    id_monitor INT,
    fecha DATE NOT NULL,
    hora_fin TIME NOT NULL,
    hora_inicio TIME NOT NULL,
    huecos INT CHECK (huecos >= 0) NOT NULL,
    precio FLOAT CHECK (precio >= 0) NOT NULL,
    PRIMARY KEY (id_actividad, id_monitor, fecha),
    FOREIGN KEY (id_actividad) REFERENCES Actividad(id) ON DELETE CASCADE,
    FOREIGN KEY (id_monitor) REFERENCES Monitor(id) ON DELETE CASCADE
);

CREATE TABLE Reserva (
    id_socio INT,
    id_actividad INT,
    fecha_alta DATE NOT NULL,
    activa BIT NOT NULL DEFAULT 1,
    PRIMARY KEY (id_socio, id_actividad),
    FOREIGN KEY (id_socio) REFERENCES Socio(id) ON DELETE CASCADE,
    FOREIGN KEY (id_actividad) REFERENCES Actividad(id) ON DELETE CASCADE
);

CREATE TABLE Informes (
    id INT PRIMARY KEY,
    Titulo VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(255),
    Fecha DATE NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    Query VARCHAR(255)
);

-- Creación de índices
CREATE INDEX idx_usuario_correo ON Usuario (Correo_electronico);
CREATE INDEX idx_usuario_dni ON Usuario (DNI);
CREATE INDEX idx_actividad_impartida_fecha ON Actividad_impartida (fecha);
CREATE INDEX idx_reserva_fecha ON Reserva (fecha_alta);

-- Triggers

-- Trigger para evitar reservas con saldo insuficiente
GO
CREATE TRIGGER before_insert_reserva
ON Reserva
FOR INSERT
AS
BEGIN
    DECLARE @actividad_precio FLOAT;
    DECLARE @id_socio INT;

    SELECT @actividad_precio = precio FROM Actividad WHERE id = (SELECT id_actividad FROM inserted);
    SELECT @id_socio = id_socio FROM inserted;

    IF (SELECT Saldo FROM Socio WHERE id = @id_socio) < @actividad_precio
    BEGIN
        RAISERROR('Saldo insuficiente para realizar la reserva', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;

-- Trigger para actualizar el saldo del socio después de insertar una reserva
GO
CREATE TRIGGER after_insert_reserva
ON Reserva
FOR INSERT
AS
BEGIN
    DECLARE @actividad_precio FLOAT;
    DECLARE @id_socio INT;

    SELECT @actividad_precio = precio FROM Actividad WHERE id = (SELECT id_actividad FROM inserted);
    SELECT @id_socio = id_socio FROM inserted;

    UPDATE Socio
    SET Saldo = Saldo - @actividad_precio
    WHERE id = @id_socio;
END;

-- Trigger para devolver el saldo si se cancela una reserva
GO
CREATE TRIGGER after_delete_reserva
ON Reserva
FOR DELETE
AS
BEGIN
    DECLARE @actividad_precio FLOAT;
    DECLARE @id_socio INT;

    SELECT @actividad_precio = precio FROM Actividad WHERE id = (SELECT id_actividad FROM deleted);
    SELECT @id_socio = id_socio FROM deleted;

    UPDATE Socio
    SET Saldo = Saldo + @actividad_precio
    WHERE id = @id_socio;
END;
