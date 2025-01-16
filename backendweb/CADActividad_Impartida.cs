﻿using System;
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
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Actividad_impartida] (Id_Actividad,Correo_Monitor,Fecha,Hora_Fin,Hora_Inicio,Huecos,Precio) VALUES (@id_actividad, @correo_monitor, @fecha, @huecos, @hora_inicio, @hora_fin,@huecos,@precio)", conec);
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@correo_monitor", SqlDbType.VarChar).Value = actividadImpartida.correo_monitorActividad;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = actividadImpartida.fechaActividad;
                consulta.Parameters.Add("@huecos", SqlDbType.Int).Value = actividadImpartida.huecosActividad;
                consulta.Parameters.Add("@hora_inicio", SqlDbType.Time).Value = actividadImpartida.horaInicioActividad;
                consulta.Parameters.Add("@hora_fin", SqlDbType.Time).Value = actividadImpartida.horaFinActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Float).Value = actividadImpartida.precioActividad;

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
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Actividad_impartida] WHERE Correo_Monitor = @correo_monitor AND Id_Actividad= @id_actividad and Fecha = @fecha", conec);

                consulta.Parameters.Add("@Correo_monitor", SqlDbType.VarChar).Value = act.correo_monitorActividad;
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = act.idActividad;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = act.fechaActividad;
                consulta.ExecuteReader();
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    act.idActividad = int.Parse(reader["Id_Actividad"].ToString());
                    act.correo_monitorActividad = reader["Correo_Monitor"].ToString();
                    act.fechaActividad = DateTime.Parse(reader["Fecha"].ToString());
                    act.huecosActividad = int.Parse(reader["Huecos"].ToString());
                    act.horaInicioActividad = TimeSpan.Parse(reader["Hora_Inicio"].ToString());
                    act.horaFinActividad = TimeSpan.Parse(reader["Hora_Fin"].ToString());
                    act.precioActividad = float.Parse(reader["Precio"].ToString());

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
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Actividad_impartida] WHERE Id_Actividad = @id_actividad AND Correo_Monitor= @correo_monitor AND Fecha= @fecha", conec);
                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@correo_monitor", SqlDbType.VarChar).Value = actividadImpartida.correo_monitorActividad;
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
                    "Id_Actividad=@id_actividad,Correo_Monitor= @correo_monitor, Fecha=@fecha, " +
                    "Huecos= @huecos, Hora_Inicio= @hora_inicio, Hora_Fin= @hora_fin , Precio = @precio" +
                    "WHERE Id_Actividad= @id_actividad AND Correo_Monitor= @correo_monitor AND Fecha= @fecha", conec);


                consulta.Parameters.Add("@id_actividad", SqlDbType.Int).Value = actividadImpartida.idActividad;
                consulta.Parameters.Add("@correo", SqlDbType.VarChar).Value = actividadImpartida.correo_monitorActividad;
                consulta.Parameters.Add("@fecha", SqlDbType.DateTime).Value = actividadImpartida.fechaActividad;
                consulta.Parameters.Add("@huecos", SqlDbType.Int).Value = actividadImpartida.huecosActividad;
                consulta.Parameters.Add("@hora_inicio", SqlDbType.Time).Value = actividadImpartida.horaInicioActividad;
                consulta.Parameters.Add("@hora_fin", SqlDbType.Time).Value = actividadImpartida.horaFinActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Int).Value = actividadImpartida.precioActividad;

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


        // Recupera las actividades impartidas con el nombre de la actividad
        public bool listarActividadesImpartidas(ref (int, string, string, DateTime)[] actividadesImpartidas)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            string query = @"
            SELECT a.Id AS IdActividad, a.Nombre AS NombreActividad, ai.Correo_Monitor, ai.Fecha
            FROM Actividad_Impartida ai
            JOIN Actividad a ON ai.Id_Actividad = a.Id
            ";

            List<(int, string, string, DateTime)> actividades = new List<(int, string, string, DateTime)>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int idActividad = reader.GetInt32(reader.GetOrdinal("IdActividad"));
                        string nombreActividad = reader.GetString(reader.GetOrdinal("NombreActividad"));
                        string correoMonitor = reader.GetString(reader.GetOrdinal("Correo_Monitor"));
                        DateTime fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"));

                        actividades.Add((idActividad, nombreActividad, correoMonitor, fecha));
                    }
                }
            }

            actividadesImpartidas = actividades.ToArray();
            return actividadesImpartidas.Length > 0;
        }

    }
}
