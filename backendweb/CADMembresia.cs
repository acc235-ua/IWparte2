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
using backEndWeb;
using System.Security.Policy;

namespace backEndWeb
{
    public class CADMembresia
    {
        private string constring;
        public CADMembresia()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool createMembresia(ENMembresia membresia)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Membresia] (Id,Descripcion,Tipo,Precio) + values(@id,@Descripcion,@Tipo,@Precio", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                consulta.Parameters.AddWithValue("@Descripcion", membresia.Descripcion);
                consulta.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                consulta.Parameters.AddWithValue("@Precio", membresia.Precio);
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

        public bool deleteMembresia(ENMembresia membresia)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Membresia] WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
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

        public bool getMembresia(ENMembresia membresia)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Membresia] WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                SqlDataReader dr = consulta.ExecuteReader();
                dr.Read();
                membresia.id = int.Parse(dr["Id"].ToString());
                membresia.Descripcion = dr["Descripcion"].ToString();
                membresia.Tipo = dr["Tipo"].ToString();
                membresia.Precio = float.Parse(dr["Precio"].ToString());
                dr.Close();
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

        public bool updateMembresia(ENMembresia membresia)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Membresia] SET Descripcion = @Descripcion, Tipo = @Tipo, Precio = @Precio WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                consulta.Parameters.AddWithValue("@Descripcion", membresia.Descripcion);
                consulta.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                consulta.Parameters.AddWithValue("@Precio", membresia.Precio);
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

        public bool readMembresia(ENMembresia membresia)
        {
            bool respuesta = false;

            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Membresia] WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    membresia.id = int.Parse(reader["Id"].ToString());
                    membresia.Descripcion = reader["Descripcion"].ToString();
                    membresia.Tipo = reader["Tipo"].ToString();
                    membresia.Precio = float.Parse(reader["Precio"].ToString());
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                respuesta = false;
                Console.WriteLine("Error", ex.Message);
            }

            return respuesta;
        }




    }
}
