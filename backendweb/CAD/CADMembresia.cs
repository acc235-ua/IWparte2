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

namespace backEndWeb
{
    public class CADMembresia
    {
        private string constring;
        public CADMembresia()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public string createMembresia(ENMembresia membresia)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Membresia] (id,Descrocion,Tipo,Precio) + values(@id,@Descripcion,@Tipo,@Precio", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                consulta.Parameters.AddWithValue("@Descripcion", membresia.Descripcion);
                consulta.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                consulta.Parameters.AddWithValue("@Precio", membresia.Precio);
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

        public string deleteMembresia(ENMembresia membresia)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Membresia] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
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

        public string getMembresia(ENMembresia membresia)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Membresia] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                SqlDataReader dr = consulta.ExecuteReader();
                dr.Read();
                membresia.id = int.Parse(dr["id"].ToString());
                membresia.Descripcion = dr["Descripcion"].ToString();
                membresia.Tipo = dr["Tipo"].ToString();
                membresia.Precio = float.Parse(dr["Precio"].ToString());
                dr.Close();
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

        public string updateMembresia(ENMembresia membresia)
        {
            string respuesta = "";
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Membresia] SET Descripcion = @Descripcion, Tipo = @Tipo, Precio = @Precio WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", membresia.id);
                consulta.Parameters.AddWithValue("@Descripcion", membresia.Descripcion);
                consulta.Parameters.AddWithValue("@Tipo", membresia.Tipo);
                consulta.Parameters.AddWithValue("@Precio", membresia.Precio);
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
