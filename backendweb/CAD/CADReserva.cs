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
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Reserva] WHERE id_socio = @id_socio AND id_actividad = @id_actividad AND id_monitor= @id_monitor AND fecha_actividad = @fecha_actividad", conec);
                consulta.Parameters.Add("@id_socio", SqlDbType.Int).Value = reserva.idSocio;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = reserva.idMonitor;
                consulta.Parameters.Add("@fecha_actividad", SqlDbType.DateTime).Value = reserva.fechaActividad;

                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    reserva.idSocio = int.Parse(reader["id_socio"].ToString());
                    reserva.idActividad = int.Parse(reader["id_actividad"].ToString());
                    reserva.idMonitor = int.Parse(reader["id_monitor"].ToString());
                    reserva.fechaActividad = DateTime.Parse(reader["fecha_actividad"].ToString());
                    reserva.fechaAltaReserva = DateTime.Parse(reader["fecha_alta"].ToString());
                    reserva.activaReserva = bool.Parse(reader["activa"].ToString());
                    leido = true;

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
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Reserva] (id_socio, id_actividad, id_monitor, fecha_actividad, fecha_alta, activa) VALUES (@id_socio, @id_actividad, @id_monitor, @fecha_actividad, @fecha_alta, @activa)", conec);
                consulta.Parameters.Add("@id_socio", SqlDbType.Int).Value = reserva.idSocio;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = reserva.idMonitor;
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
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Reserva] SET activa = @activa, fecha_alta = @fecha_alta WHERE id_socio = @id_socio AND id_actividad = @id_actividad AND id_monitor = @id_monitor AND fecha_actividad = @fecha_actividad", conec);
                consulta.Parameters.Add("@id_socio", SqlDbType.Int).Value = reserva.idSocio;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = reserva.idMonitor;
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
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Reserva] WHERE id_socio = @id_socio AND id_actividad = @id_actividad AND id_monitor = @id_monitor AND fecha_actividad = @fecha_actividad", conec);
                consulta.Parameters.Add("@id_socio", SqlDbType.Int).Value = reserva.idSocio;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = reserva.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = reserva.idMonitor;
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
