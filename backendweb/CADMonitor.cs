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

        public bool createMonitor(ENMonitor monitor)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Monitor] (Correo_electronico,Especialidad,Salario,Telefono) + values(@correo,@especialidad,@salario,@telefono", conec);
                consulta.Parameters.AddWithValue("@correo", monitor.correo);
                consulta.Parameters.AddWithValue("@especialidad", monitor.especialidad);
                consulta.Parameters.AddWithValue("@salario", monitor.salario);
                consulta.Parameters.AddWithValue("@telefono", monitor.telefono);
                consulta.ExecuteNonQuery();
                respuesta = true;
            }
            catch (SqlException ex)
            {
                respuesta = false;
            }
            finally
            {
                conec.Close();
            }

            return respuesta;

        }

        public bool deleteMonitor(ENMonitor monitor)
        {
            bool respuesta = false; ;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Monitor] WHERE Correo_electronico = @correo", conec);
                consulta.Parameters.AddWithValue("@correo", monitor.correo);
                consulta.ExecuteNonQuery();
                respuesta = true;
            }
            catch (SqlException ex)
            {
                respuesta = false;
            }
            finally
            {
                conec.Close();
            }
            return respuesta;
        }

        public bool updateMonitor(ENMonitor monitor)
        {
            bool respuesta =false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Monitor] SET, " +
                    "Especialidad=@especialidad, Salario= @salario, Telefono=@telefono" +
                    "WHERE Correo_electronico= @correo", conec);
                consulta.Parameters.AddWithValue("@correo", monitor.correo);
                consulta.Parameters.AddWithValue("@especialidad", monitor.especialidad);
                consulta.Parameters.AddWithValue("@salario", monitor.salario);
                consulta.Parameters.AddWithValue("@telefono", monitor.telefono);
                consulta.ExecuteNonQuery();
                respuesta = true;
            }
            catch (SqlException ex)
            {
                respuesta = false;
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
                    u.Correo_electronico, 
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
                    Monitor m ON u.Correo_electronico = m.Correo_electronico";

                SqlCommand consulta = new SqlCommand(query, conec);
                SqlDataReader reader = consulta.ExecuteReader();
                while (reader.Read())
                {
                    ENMonitor monitor = new ENMonitor();
                    monitor.correo = reader.GetString(0);
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

        public bool readMonitor(ENMonitor monitor)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Monitor] WHERE Correo_electronico = @correo", conec);
                consulta.Parameters.AddWithValue("@correo", monitor.correo);
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    monitor.correo = reader.GetString(0);
                    monitor.especialidad = reader.GetString(1);
                    monitor.salario = reader.GetFloat(2);
                    monitor.telefono = reader.GetString(3);
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                respuesta = false;
            }
            finally
            {
                conec.Close();
            }
            return respuesta;
        }
    }
}
