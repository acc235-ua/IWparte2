using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gimnasio
{
    public partial class Actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetActivities(string fecha)
        {
            string connectionString = "tu_connection_string_aqui";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Consulta para obtener las actividades del día seleccionado
                string query = @"SELECT a.Id, a.Nombre, a.Precio
                                 FROM Actividad a
                                 JOIN Actividad_impartida ai ON a.Id = ai.Id_Actividad
                                 WHERE ai.Fecha = @Fecha";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Fecha", fecha);

                SqlDataReader reader = cmd.ExecuteReader();
                List<object> actividades = new List<object>();

                while (reader.Read())
                {
                    actividades.Add(new
                    {
                        Id = reader["Id"],
                        Nombre = reader["Nombre"],
                        Precio = reader["Precio"]
                    });
                }

                return JsonConvert.SerializeObject(actividades);
            }
        }

        [WebMethod]
        public static string ReserveActivity(string activityId, string userId)
        {
            string connectionString = "tu_connection_string_aqui";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Verificar saldo del usuario
                string querySaldo = "SELECT Saldo FROM Socio WHERE Correo_electronico = @UserId";
                SqlCommand cmdSaldo = new SqlCommand(querySaldo, conn);
                cmdSaldo.Parameters.AddWithValue("@UserId", userId);
                var saldo = cmdSaldo.ExecuteScalar();

                string queryPrecio = "SELECT Precio FROM Actividad WHERE Id = @ActivityId";
                SqlCommand cmdPrecio = new SqlCommand(queryPrecio, conn);
                cmdPrecio.Parameters.AddWithValue("@ActivityId", activityId);
                var precio = cmdPrecio.ExecuteScalar();

                if (saldo != null && Convert.ToDecimal(saldo) >= Convert.ToDecimal(precio))
                {
                    // Restar saldo
                    string updateSaldo = "UPDATE Socio SET Saldo = Saldo - @Precio WHERE Correo_electronico = @UserId";
                    SqlCommand cmdUpdateSaldo = new SqlCommand(updateSaldo, conn);
                    cmdUpdateSaldo.Parameters.AddWithValue("@Precio", precio);
                    cmdUpdateSaldo.Parameters.AddWithValue("@UserId", userId);
                    cmdUpdateSaldo.ExecuteNonQuery();

                    // Insertar reserva
                    string insertReserva = "INSERT INTO Reserva (Correo_Socio, Id_Actividad) VALUES (@UserId, @ActivityId)";
                    SqlCommand cmdInsertReserva = new SqlCommand(insertReserva, conn);
                    cmdInsertReserva.Parameters.AddWithValue("@UserId", userId);
                    cmdInsertReserva.Parameters.AddWithValue("@ActivityId", activityId);
                    cmdInsertReserva.ExecuteNonQuery();

                    return JsonConvert.SerializeObject(new { success = true });
                }
                else
                {
                    return JsonConvert.SerializeObject(new { success = false, message = "Saldo insuficiente" });
                }
            }
        }
    }
}