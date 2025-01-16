using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace gimnasio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Limpiar mensaje de error
            errorCorreo.Text = "";
            errorContrasena.Text = "";

            // Obtener correo y contraseña del formulario
            string correo = email.Text.Trim();
            string contrasenaUsuario = contrasena.Text.Trim();

            if (string.IsNullOrEmpty(email.Text))
            {
                errorCorreo.Text = "Introduce un correo electrónico";
                return;
            }

            if (string.IsNullOrEmpty(contrasena.Text))
            {
                errorContrasena.Text = "Introduce una contraseña";
                return;
            }

            // Conexión a la base de datos
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consultar el usuario y si es administrador
                    string query = "SELECT Contrasena, Es_admin FROM Usuario WHERE Correo_electronico = @Correo";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string contrasenaEnDb = reader["Contrasena"].ToString();
                                bool esAdmin = Convert.ToBoolean(reader["Es_admin"]);

                                // Comprobar si la contraseña coincide
                                if (contrasenaUsuario == contrasenaEnDb)
                                {
                                    // Redirigir según el rol
                                    if (esAdmin)
                                    {
                                        Response.Redirect("VerActividades.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("Actividades.aspx");
                                    }
                                }
                                else
                                {
                                    errorContrasena.Text = "La contraseña es incorrecta.";
                                }
                            }
                            else
                            {
                                errorCorreo.Text = "El correo electrónico no está registrado.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorCorreo.Text = $"Error al conectar con la base de datos: {ex.Message}";
            }
        }
    }
}
