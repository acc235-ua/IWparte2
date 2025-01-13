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

        public string createCategoria(ENCategoria categoria)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Categoria] (id,Nombre) + values(@id,@Nombre", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
                consulta.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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

        public string deleteCategoria(ENCategoria categoria)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Categoria] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
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

        public string updateCategoria(ENCategoria categoria)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Categoria] SET Nombre = @Nombre WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", categoria.id);
                consulta.Parameters.AddWithValue("@Nombre", categoria.Nombre);
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





    }
}
