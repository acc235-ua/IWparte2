using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using backEndWeb;

namespace gimnasio
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Limpiar mensajes de error
            errorCorreo.Text = "";
            errorApellidos.Text = "";
            errorNombre.Text = "";
            errorContrasena.Text = "";
            errorDni.Text = "";
            errorTarifa.Text = "";
            bool ok = false;

            // Validar el correo electrónico
            if (!email.Text.Contains("@"))
            {
                errorCorreo.Text = "Por favor, ingresa un correo válido. Ejemplo: ejemplo@dominio.com.";
                return;
            }

            // Validar que se haya seleccionado una tarifa
            if (string.IsNullOrEmpty(tarifa.SelectedValue))
            {
                errorCorreo.Text = "Por favor, selecciona una tarifa. Ejemplo: 'Estudiante', 'Jubilado' o 'Standard'.";
                return;
            }

            // Validar el DNI (por ejemplo, formato "12345678A")
            string dni = DNI.Text.Trim();
            if (!Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$"))
            {
                errorDni.Text = "Por favor, ingresa un DNI válido. Ejemplo: 12345678A.";
                return;
            }

            if (string.IsNullOrEmpty(contrasena.Text))
            {
                errorContrasena.Text = "Por favor, introduce una contraseña";
                return;
            }

            if (string.IsNullOrEmpty(email.Text))
            {
                errorCorreo.Text = "Por favor, introduce un correo electrónico";
                return;
            }

            if (string.IsNullOrEmpty(DNI.Text))
            {
                errorDni.Text = "Por favor, introduce un DNI";
                return;
            }

            if (string.IsNullOrEmpty(nombre.Text))
            {
                errorNombre.Text = "Por favor, introduce un nombre";
                return;
            }

            if (string.IsNullOrEmpty(apellidos.Text))
            {
                errorApellidos.Text = "Por favor, introduce tu/s apellido/s";
                return;
            }

            // Obtener datos del formulario
            string correo = email.Text.Trim();
            string nombreUsuario = nombre.Text.Trim();
            string apellidosUsuario = apellidos.Text.Trim();
            string tarifaSeleccionada = tarifa.SelectedValue;

            // Asignar Membresía según tarifa
            int membresiaId;

            switch (tarifaSeleccionada)
            {
                case "Estudiante":
                    membresiaId = 1; // Id de la membresía "Estudiante"
                    break;
                case "Jubilado":
                    membresiaId = 2; // Id de la membresía "Jubilado"
                    break;
                case "Standard":
                    membresiaId = 3; // Id de la membresía "Standard"
                    break;
                default:
                    membresiaId = 0; // Por defecto, no asignar
                    break;
            }

            if (membresiaId == 0)
            {
                errorTarifa.Text = "La tarifa seleccionada no es válida.";
                return;
            }

            // Conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Iniciar una transacción
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insertar en la tabla Usuario
                            string insertUsuarioQuery = @"
                                INSERT INTO Usuario (Correo_electronico, Nombre, Apellidos, DNI, Contrasena, Es_admin)
                                VALUES (@Correo, @Nombre, @Apellidos, @DNI, @Contrasena, @EsAdmin)";

                            using (SqlCommand cmd = new SqlCommand(insertUsuarioQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Correo", correo);
                                cmd.Parameters.AddWithValue("@Nombre", nombreUsuario);
                                cmd.Parameters.AddWithValue("@Apellidos", apellidosUsuario);
                                cmd.Parameters.AddWithValue("@DNI", dni);
                                cmd.Parameters.AddWithValue("@Contrasena", contrasena.Text.Trim()); // Usar la contraseña ingresada
                                cmd.Parameters.AddWithValue("@EsAdmin", 0); // No es administrador
                                cmd.ExecuteNonQuery();
                            }

                            // Insertar en la tabla Socio
                            string insertSocioQuery = @"
                                INSERT INTO Socio (Correo_electronico, Saldo, Estado, MembresiaId)
                                VALUES (@Correo, @Saldo, @Estado, @MembresiaId)";

                            using (SqlCommand cmd = new SqlCommand(insertSocioQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@Correo", correo);
                                cmd.Parameters.AddWithValue("@Saldo", 0); // Saldo inicial
                                cmd.Parameters.AddWithValue("@Estado", "pendiente"); // Estado inicial
                                cmd.Parameters.AddWithValue("@MembresiaId", membresiaId);
                                cmd.ExecuteNonQuery();
                            }

                            // Confirmar la transacción
                            transaction.Commit();
                            Response.Write("<script>alert('Registro completado con éxito');</script>");
                            ok = true;
                        }
                        catch (Exception ex)
                        {
                            // Revertir transacción en caso de error
                            transaction.Rollback();
                            errorCorreo.Text = $"Error al registrar el usuario: {ex.Message}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorCorreo.Text = $"Error de conexión a la base de datos: {ex.Message}";
            }

            if (ok)
            {
                Response.Redirect("Inicio.aspx");
            }
        }
    }
}
