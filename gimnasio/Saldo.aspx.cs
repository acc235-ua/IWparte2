using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gimnasio
{
    public partial class Saldo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarSaldo();
            }
        }

        private void MostrarSaldo()
        {
            string correoUsuario = Session["Correo_electronico"]?.ToString();
            
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Saldo FROM Socio WHERE Correo_electronico = @Correo_electronico";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Correo_electronico", correoUsuario);

                try
                {
                    connection.Open();
                    object saldo = command.ExecuteScalar();
                    lblSaldo.Text = saldo != null
                        ? $"Tu saldo actual es: {saldo}€"
                        : "No se pudo encontrar tu saldo.";
                }
                catch (Exception ex)
                {
                    lblSaldo.Text = "Error al obtener el saldo. Por favor, inténtelo más tarde.";
                    // Log del error para depuración.
                }
            }
        }

        protected void btnRecargar_Click(object sender, EventArgs e)
        {

            if (!decimal.TryParse(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                lblRecargaMensaje.Text = "Por favor, introduce un importe válido.";
                return;
            }

            // Validación de tarjeta
            if (string.IsNullOrEmpty(txtTarjeta.Text) || txtTarjeta.Text.Length < 16 || string.IsNullOrEmpty(txtCVV.Text))
            {
                lblRecargaMensaje.Text = "Por favor, introduce datos válidos de la tarjeta.";
                return;
            }
        }
    }
}   
