using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.ComponentModel.Design;
using System.Configuration;
using backendweb;

namespace backEndWeb
{
    public class CADMonitor
    {

        private string constring;
        public CADMonitor()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();

        }

        public string createMonitor(ENMonitor monitor)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Monitor] (id,especialidad,salario,telefono) + values(@id,@especialidad,@salario,@telefono", conec);
                consulta.Parameters.AddWithValue("@id", monitor.id);
                consulta.Parameters.AddWithValue("@especialidad", monitor.especialidad);
                consulta.Parameters.AddWithValue("@salario", monitor.salario);
                consulta.Parameters.AddWithValue("@telefono", monitor.telefono);
                consulta.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            finally
            {
                conec.Close();
            }

            return respuesta;

        }

        public string deleteMonitor(ENMonitor monitor)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Monitor] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", monitor.id);
                consulta.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            finally
            {
                conec.Close();
            }
            return respuesta;
        }

        public string updateMonitor(ENMonitor monitor)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Monitor] SET, " +
                    "especialidad=@especialidad, salario= @salario, telefono=@telefono" +
                    "WHERE id= @id", conec);
                consulta.Parameters.AddWithValue("@id", monitor.id);
                consulta.Parameters.AddWithValue("@especialidad", monitor.especialidad);
                consulta.Parameters.AddWithValue("@salario", monitor.salario);
                consulta.Parameters.AddWithValue("@telefono", monitor.telefono);
                consulta.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            finally
            {
                conec.Close();
            }
            return respuesta;
        }

        public List<ENMonitor> getAllMonitores()
        {
            List<ENMonitor> monitores = new List<ENMonitor>();
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                string query = @"
                SELECT 
                    u.id, 
                    u.Nombre, 
                    u.Apellidos, 
                    u.DNI, 
                    u.Correo_electronico, 
                    m.especialidad,
                    m.salario
                    m.telefono
                FROM 
                    Usuario u
                INNER JOIN 
                    Monitor m ON u.id = m.id";

                SqlCommand consulta = new SqlCommand(query, conec);
                SqlDataReader reader = consulta.ExecuteReader();
                while (reader.Read())
                {
                    ENMonitor monitor = new ENMonitor();
                    monitor.id = reader.GetInt32(0);
                    monitor.Nombre = reader.GetString(1);
                    monitor.Apellidos = reader.GetString(2);
                    monitor.DNI = reader.GetString(3);
                    monitor.CorreoElectronico = reader.GetString(4);
                    monitor.especialidad = reader.GetString(5);
                    monitor.salario = reader.GetFloat(6);
                    monitor.telefono = reader.GetString(7);
                    monitores.Add(monitor);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return monitores;
        }
    }
}
