-- Actualizar la tabla Usuario
CREATE TABLE [dbo].[Usuario] (
    [Correo_electronico] VARCHAR (255) NOT NULL PRIMARY KEY, -- Clave primaria
    [Apellidos]          VARCHAR (255) NOT NULL,
    [DNI]                VARCHAR (20)  NOT NULL UNIQUE,      -- Mantener único
    [Es_admin]           BIT           DEFAULT ((0)) NOT NULL,
    [Contrasena]         VARCHAR (255) NOT NULL,
    [nombre]             NVARCHAR (100) NOT NULL
);

-- Crear la tabla Monitor
CREATE TABLE [dbo].[Monitor] (
    [Correo_electronico] VARCHAR (255) NOT NULL,             -- Referencia a Usuario
    [especialidad]       VARCHAR (255) NOT NULL,
    [salario]            FLOAT (53)    NOT NULL,
    [telefono]           VARCHAR (20)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Correo_electronico] ASC),
    FOREIGN KEY ([Correo_electronico]) REFERENCES [dbo].[Usuario] ([Correo_electronico]) ON DELETE CASCADE,
    CHECK ([salario] >= (0))
);

-- Crear la tabla Membresia primero ya que Socio depende de ella
CREATE TABLE [dbo].[Membresia] (
    Id           INT PRIMARY KEY,
    Descripcion  VARCHAR(255) NOT NULL,
    Tipo         VARCHAR(50) NOT NULL,
    Precio       FLOAT CHECK (Precio >= 0) NOT NULL
);

-- Crear la tabla Socio
CREATE TABLE [dbo].[Socio] (
    Correo_electronico VARCHAR(255) NOT NULL PRIMARY KEY,
    Saldo              INT          DEFAULT ((0)) CHECK (Saldo >= 0),
    Estado             VARCHAR(50)  NOT NULL,
    MembresiaId        INT          NULL,
    FOREIGN KEY (Correo_electronico) REFERENCES [dbo].[Usuario] (Correo_electronico) ON DELETE CASCADE,
    FOREIGN KEY (MembresiaId) REFERENCES [dbo].[Membresia] (Id) ON DELETE SET NULL
);

-- Crear la tabla Categoria
CREATE TABLE [dbo].[Categoria] (
    Id     INT PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL
);

-- Crear la tabla Actividad
CREATE TABLE [dbo].[Actividad] (
    Id           INT PRIMARY KEY,
    Nombre       VARCHAR(255) NOT NULL,
    Descripcion  VARCHAR(255),
    Precio       FLOAT CHECK (Precio >= 0) NOT NULL,
    Id_Categoria INT NOT NULL,
    FOREIGN KEY (Id_Categoria) REFERENCES [dbo].[Categoria] (Id) ON DELETE CASCADE
);

-- Crear la tabla Actividad_impartida
CREATE TABLE [dbo].[Actividad_impartida] (
    Id_Actividad    INT NOT NULL,
    Correo_Monitor  VARCHAR(255) NOT NULL,
    Fecha           DATE NOT NULL,
    Hora_Inicio     TIME NOT NULL,
    Hora_Fin        TIME NOT NULL,
    Huecos          INT CHECK (Huecos >= 0) NOT NULL,
    Precio          FLOAT CHECK (Precio >= 0) NOT NULL,
    PRIMARY KEY (Id_Actividad, Correo_Monitor, Fecha),
    FOREIGN KEY (Id_Actividad) REFERENCES [dbo].[Actividad] (Id) ON DELETE CASCADE,
    FOREIGN KEY (Correo_Monitor) REFERENCES [dbo].[Monitor] (Correo_electronico) ON DELETE CASCADE
);

-- Crear la tabla Reserva
CREATE TABLE [dbo].[Reserva] (
    Correo_Socio        VARCHAR(255) NOT NULL,
    Id_Actividad        INT NOT NULL,
    Correo_Monitor      VARCHAR(255) NOT NULL,
    Fecha_Actividad     DATE NOT NULL,
    Fecha_Alta          DATE NOT NULL,
    Activa              BIT DEFAULT ((1)) NOT NULL,
    PRIMARY KEY (Correo_Socio, Id_Actividad, Correo_Monitor, Fecha_Actividad),
    FOREIGN KEY (Correo_Socio) REFERENCES [dbo].[Socio] (Correo_electronico) ON DELETE NO ACTION,
    FOREIGN KEY (Id_Actividad, Correo_Monitor, Fecha_Actividad) 
        REFERENCES [dbo].[Actividad_impartida] (Id_Actividad, Correo_Monitor, Fecha) ON DELETE NO ACTION
);

-- Crear la tabla Informes
CREATE TABLE [dbo].[Informes] (
    Id          INT PRIMARY KEY,
    Titulo      VARCHAR(255) NOT NULL,
    Descripcion VARCHAR(255),
    Fecha       DATE NOT NULL,
    Estado      VARCHAR(50) NOT NULL,
    Query       VARCHAR(255)
);

-- Crear índices
CREATE INDEX idx_usuario_correo ON [dbo].[Usuario] (Correo_electronico);
CREATE INDEX idx_usuario_dni ON [dbo].[Usuario] (DNI);
CREATE INDEX idx_actividad_impartida_fecha ON [dbo].[Actividad_impartida] (Fecha);
CREATE INDEX idx_reserva_fecha ON [dbo].[Reserva] (Fecha_Alta);

-- Crear triggers después de las tablas
GO
CREATE TRIGGER after_insert_reserva
ON [dbo].[Reserva]
AFTER INSERT
AS
BEGIN
    DECLARE @actividad_precio FLOAT;
    DECLARE @correo_socio VARCHAR(255);

    SELECT @actividad_precio = Precio 
    FROM [dbo].[Actividad] 
    WHERE Id = (SELECT Id_Actividad FROM inserted);

    SELECT @correo_socio = Correo_Socio FROM inserted;

    UPDATE [dbo].[Socio]
    SET Saldo = Saldo - @actividad_precio
    WHERE Correo_electronico = @correo_socio;
END;

GO
CREATE TRIGGER after_delete_reserva
ON [dbo].[Reserva]
AFTER DELETE
AS
BEGIN
    DECLARE @actividad_precio FLOAT;
    DECLARE @correo_socio VARCHAR(255);

    SELECT @actividad_precio = Precio 
    FROM [dbo].[Actividad] 
    WHERE Id = (SELECT Id_Actividad FROM deleted);

    SELECT @correo_socio = Correo_Socio FROM deleted;

    UPDATE [dbo].[Socio]
    SET Saldo = Saldo + @actividad_precio
    WHERE Correo_electronico = @correo_socio;
END;

