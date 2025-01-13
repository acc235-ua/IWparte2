using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using System.Configuration;
using backendweb.EN;
using backEndWeb;




namespace backendweb.CAD
{
    public class CADActividad_Impartida
    {
        private string constring;
        public CADActividad_Impartida()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool createActividadImpartida(ENActividad_Impartida actividadImpartida)
        {

            SqlConnection conec = new SqlConnection(constring);
            bool creado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Actividad_impartida] (id_actividad, id_monitor, fecha,hora_fin, hora_inicio,huecos) VALUES (@id_actividad, @id_monitor, @fecha, @huecos, @hora_inicio, @hora_fin)", conec);
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = actividadImpartida.idMonitor;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = actividadImpartida.fechaActividad;
                consulta.Parameters.Add("@huecos", SqlDbType.Int).Value = actividadImpartida.huecosActividad;
                consulta.Parameters.Add("@hora_inicio", SqlDbType.Time).Value = actividadImpartida.horaInicioActividad;
                consulta.Parameters.Add("@hora_fin", SqlDbType.Time).Value = actividadImpartida.horaFinActividad;
                consulta.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException ex)
            {
                creado = false;
                Console.WriteLine("Operación crear falla en CADActividad_Impartida {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return creado;
        }

        public bool readActividad_Impartida(ENActividad_Impartida act)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool leido = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Actividad_impartida] WHERE id_monitor = @id_monitor AND id_actividad= @id_actividad and fecha = @fecha", conec);

                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = act.idMonitor;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = act.idActividad;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = act.fechaActividad;
                consulta.ExecuteReader();
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    act.idActividad = int.Parse(reader["id_actividad"].ToString());
                    act.idMonitor = int.Parse(reader["id_monitor"].ToString());
                    act.fechaActividad = DateTime.Parse(reader["fecha"].ToString());
                    act.huecosActividad = int.Parse(reader["huecos"].ToString());
                    act.horaInicioActividad = TimeSpan.Parse(reader["hora_inicio"].ToString());
                    act.horaFinActividad = TimeSpan.Parse(reader["hora_fin"].ToString());
                    
                    leido = true;
                }
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Operación leer falla en CADActividad_Impartida {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return leido;

        }


        public bool deleteActividadImpartida(ENActividad_Impartida actividadImpartida)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool borrado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Actividad_impartida] WHERE id_actividad = @id_actividad AND id_monitor= @id_monitor AND fecha= @fecha", conec);
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = actividadImpartida.idMonitor;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = actividadImpartida.fechaActividad;
                consulta.ExecuteNonQuery();
                borrado = true;
            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Operación borrar falla en CADActividad_Impartida {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return borrado;
        }

        public bool updateActividadImpartida(ENActividad_Impartida actividadImpartida)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool borrado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Usuario] SET, " +
                    "id_actividad=@id_actividad, id_monitor= @id_monitor, fecha=@fecha, " +
                    "huecos= @huecos, hora_inicio= @hora_inicio, hora_fin= @hora_fin" +
                    "WHERE id_actividad= @id_actividad AND id_monitor= @id_monitor AND fecha= @fecha", conec);


                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@id_monitor", SqlDbType.Int).Value = actividadImpartida.idMonitor;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = actividadImpartida.fechaActividad;
                consulta.Parameters.Add("@huecos", SqlDbType.Int).Value = actividadImpartida.huecosActividad;
                consulta.Parameters.Add("@hora_inicio", SqlDbType.Time).Value = actividadImpartida.horaInicioActividad;
                consulta.Parameters.Add("@hora_fin", SqlDbType.Time).Value = actividadImpartida.horaFinActividad;

                consulta.ExecuteNonQuery();
                borrado = true;

            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Operación actualizar falla en CADActividad_Impartida {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return borrado;
        }


        public bool listarActividadesImpartidas(ref (int, int, DateTime)[] usuarios)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool respuesta = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("SELECT id_actividad, id_monitor , fecha FROM [dbo].[Actividad_impartida]", conec);

                SqlDataReader leerDatos = consulta.ExecuteReader();
                List<(int, int, DateTime)> listaTemporal = new List<(int, int, DateTime)>();

                while (leerDatos.Read())
                {
                    int id_actividad = int.Parse(leerDatos["id_actividad"].ToString());
                    int id_monitor = int.Parse(leerDatos["id_monitor"].ToString());
                    DateTime fecha = DateTime.Parse(leerDatos["fecha"].ToString());
                    listaTemporal.Add((id_actividad, id_monitor, fecha));
                }
                usuarios = listaTemporal.ToArray();
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                Console.WriteLine("Error en CAD listando actividades impartidas: ", ex.Message);
            }
            finally
            {
                conec.Close();
            }

            return respuesta;

        }
    }
}
