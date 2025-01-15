using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            string connectionString = "Data Source=TU_SERVIDOR;Initial Catalog=TU_BD;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Consultar el usuario en la base de datos
                    string query = "SELECT Contrasena FROM Usuario WHERE Correo_electronico = @Correo";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // Comprobar si la contraseña coincide
                            string contrasenaEnDb = result.ToString();
                            if (contrasenaUsuario == contrasenaEnDb)
                            {
                                // Redirigir al usuario a otra página si las credenciales son correctas
                                Response.Redirect("Actividades.aspx");
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
            catch (Exception ex)
            {
                errorCorreo.Text = $"Error al conectar con la base de datos: {ex.Message}";
            }
        }
    }
}