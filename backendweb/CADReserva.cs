using backendweb.EN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.ComponentModel.Design;


namespace backendweb.CAD
{
    public class CADReserva
    {
        private string constring;
        public CADReserva()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool readReserva(ENReserva reserva)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool leido = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Reserva] WHERE Correo_Socio = @correo_socio AND Id_Actividad = @id_actividad AND Correo_Monitor= @correo_monitor AND Fecha_Actividad = @fecha_Actividad ", conec);
                consulta.Parameters.Add("@correo_socio", SqlDbType.VarChar).Value = reserva.CorreoSocioActividad;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@correo_monitor", SqlDbType.VarChar).Value = reserva.CorreoSocioActividad;
                consulta.Parameters.Add("@fecha_actividad", SqlDbType.DateTime).Value = reserva.fechaActividad;

                // Using statement ensures proper disposal of the SqlDataReader
                using (SqlDataReader reader = consulta.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reserva.CorreoMonitorActividad = reader["Correo_Actividad"].ToString();
                        reserva.idActividad = int.Parse(reader["Id_Actividad"].ToString());
                        reserva.CorreoSocioActividad = reader["Correo_Monitor"].ToString();
                        reserva.fechaActividad = DateTime.Parse(reader["Fecha_Actividad"].ToString());
                        reserva.fechaAltaReserva = DateTime.Parse(reader["Fecha_Alta"].ToString());
                        reserva.activaReserva = bool.Parse(reader["Activa"].ToString());
                        leido = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Operación leer falla en CADReserva {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return leido;
        }


        public bool createReserva(ENReserva reserva)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool creado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Reserva] (Correo_Socio, Id_Actividad, Correo_Monitor, Fecha_Actividad, Fecha_Alta, Activa) VALUES (@correo_socio, @id_actividad, @correo_monitor, @fecha_actividad, @fecha_alta, @activa)", conec);
                consulta.Parameters.Add("@correo_socio", SqlDbType.VarChar).Value = reserva.CorreoSocioActividad;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@correo_monitor", SqlDbType.VarChar).Value = reserva.CorreoMonitorActividad;
                consulta.Parameters.Add("@fecha_actividad", SqlDbType.DateTime).Value = reserva.fechaActividad;
                consulta.Parameters.Add("@fecha_alta", SqlDbType.DateTime).Value = reserva.fechaAltaReserva;
                consulta.Parameters.Add("@activa", SqlDbType.Bit).Value = reserva.activaReserva;
                consulta.ExecuteNonQuery();
                creado = true;

            }
            catch (SqlException ex)
            {
                creado = false;
                Console.WriteLine("Operación crear falla en CADReserva {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return creado;
        }

        public bool updateReserva(ENReserva reserva)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool creado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Reserva] SET Activa = @activa, Fecha_Alta = @fecha_alta WHERE Correo_Socio = @correo_socio AND Id_Actividad = @id_actividad AND Correo_Monitor = @correo_monitor AND Fecha_Actividad = @fecha_actividad", conec);
                consulta.Parameters.Add("@correo_monitor", SqlDbType.VarChar).Value = reserva.CorreoMonitorActividad;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@correo_socio", SqlDbType.Int).Value = reserva.CorreoSocioActividad;
                consulta.Parameters.Add("@fecha_actividad", SqlDbType.DateTime).Value = reserva.fechaActividad;
                consulta.Parameters.Add("@fecha_alta", SqlDbType.DateTime).Value = reserva.fechaAltaReserva;
                consulta.Parameters.Add("@activa", SqlDbType.Bit).Value = reserva.activaReserva;
                consulta.ExecuteNonQuery();
                creado = true;

            }
            catch (Exception ex)
            {
                creado = false;
                Console.WriteLine("Operación actualizar falla en CADReserva {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return creado;
        }

        public bool deleteReserva(ENReserva reserva)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool borrado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Reserva] WHERE Correo_socio = @correo_socio AND Id_Actividad = @id_actividad AND Correo_Monitor = @correo_monitor AND Fecha_Actividad = @fecha_actividad", conec);
                consulta.Parameters.Add("@correo_socio", SqlDbType.VarChar).Value = reserva.CorreoSocioActividad;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@correo_monitor", SqlDbType.Int).Value = reserva.CorreoMonitorActividad;
                consulta.Parameters.Add("@fecha_actividad", SqlDbType.DateTime).Value = reserva.fechaActividad;
                consulta.ExecuteNonQuery();
                borrado = true;

            }
            catch (Exception ex)
            {
                borrado = false;
                Console.WriteLine("Operación borrar falla en CADReserva {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return borrado;
        }
    }
}
