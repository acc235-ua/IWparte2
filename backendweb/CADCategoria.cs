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

namespace backEndWeb
{
    public class CADCategoria
    {

        private string constring;
        public CADCategoria()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool createCategoria(ENCategoria categoria)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Categoria] (Id,Nombre) + values(@id,@Nombre", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
                consulta.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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

        public bool deleteCategoria(ENCategoria categoria)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Categoria] WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
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

        public bool updateCategoria(ENCategoria categoria)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Categoria] SET Nombre = @Nombre WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
                consulta.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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

        public bool readCategoria(ENCategoria categoria)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Categoria] WHERE Id = @id", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    categoria.id = reader.GetInt32(0);
                    categoria.Nombre = reader.GetString(1);
                    respuesta = true;
                }
            }
            catch (SqlException ex)
            {
                respuesta = false;
                Console.WriteLine("Operación leer falla en CADCategoria {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return respuesta;
        }   





    }
}
