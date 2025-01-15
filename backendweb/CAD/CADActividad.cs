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
    public class CADActividad
    {

        private string constring;
        public CADActividad()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();

        }

        public bool createActividad(ENActividad actividad)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool creado = false;
            try
            {
                conec.Open();

                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Actividad] (Id, Nombre, Descripcion, Precio, Id_Categoria) VALUES (@id, @nombre, @descripcion, @precio, @id_categoria)", conec);

                //consulta.Parameters.AddWithValue("@id", actividad.idActividad);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                consulta.Parameters.Add("@nombre", SqlDbType.VarChar).Value = actividad.nombreActividad;
                consulta.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = actividad.descripcionActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Float).Value = actividad.precioActividad;
                consulta.Parameters.Add("@id_categoria", SqlDbType.Int).Value = actividad.idCategoriaActividad;

                consulta.ExecuteNonQuery();
                creado = true;
            }
            catch (SqlException ex)
            {
                creado = false;
                Console.WriteLine("Operación crear falla en CADActividad {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return creado;

        }

        public bool deleteActividad(ENActividad actividad)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool borrado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Actividad] WHERE Id = @id", conec);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;

                consulta.ExecuteNonQuery();
                borrado = true;
            }
            catch (SqlException ex)
            {
                borrado = false;
                Console.WriteLine("Operación borrar falla en CADActividad {0}", ex.Message);
            }
            finally
            {
                conec.Close();

            }
            return borrado;
        }

        public bool updateActividad(ENActividad actividad)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool actualizado = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Actividad] SET Nombre = @nombre, Descripcion = @descripcion, Precio = @precio, Id_Categoria = @id_categoria WHERE Id = @id", conec);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                consulta.Parameters.Add("@nombre", SqlDbType.VarChar).Value = actividad.nombreActividad;
                consulta.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = actividad.descripcionActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Float).Value = actividad.precioActividad;
                consulta.Parameters.Add("@id_categoria", SqlDbType.Int).Value = actividad.idCategoriaActividad;
                consulta.ExecuteNonQuery();
                actualizado = true;
            }
            catch (SqlException ex)
            {
                actualizado = false;
                Console.WriteLine("Operación actualizar falla en CADActividad {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return actualizado;
        }

        public bool readActividad(ENActividad actividad)
        {
            SqlConnection conec = new SqlConnection(constring);
            bool leido = false;
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Actividad] WHERE Id = @id", conec);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    
                    actividad.idActividad = int.Parse(reader["Id"].ToString());
                    actividad.nombreActividad = reader["Nombre"].ToString();
                    actividad.descripcionActividad = reader["Descripcion"].ToString();
                    actividad.precioActividad = float.Parse(reader["Precio"].ToString());
                    actividad.idCategoriaActividad = int.Parse(reader["Id_Categoria"].ToString());
                    leido = true;
                }
            }
            catch (SqlException ex)
            {
                leido = false;
                Console.WriteLine("Operación leer falla en CADActividad {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }
            return leido;
        }
    }
}
//nombre apellidos