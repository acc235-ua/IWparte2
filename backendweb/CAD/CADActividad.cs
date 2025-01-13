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

                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Actividad] (id, Nombre, Descripcion, precio, id_categoria) VALUES (@id, @nombre, @descripcion, @precio, @id_categoria)", conec);

                //consulta.Parameters.AddWithValue("@id", actividad.idActividad);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                consulta.Parameters.Add("@nombre", SqlDbType.VarChar).Value = actividad.nombreActividad;
                consulta.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = actividad.descripcionActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Int).Value = actividad.precioActividad;
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
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Actividad] WHERE id = @id", conec);
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
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Actividad] SET Nombre = @nombre, Descripcion = @descripcion, precio = @precio, id_categoria = @id_categoria WHERE id = @id", conec);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                consulta.Parameters.Add("@nombre", SqlDbType.VarChar).Value = actividad.nombreActividad;
                consulta.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = actividad.descripcionActividad;
                consulta.Parameters.Add("@precio", SqlDbType.Int).Value = actividad.precioActividad;
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
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Actividad] WHERE id = @id", conec);
                consulta.Parameters.Add("@id", SqlDbType.Int).Value = actividad.idActividad;
                SqlDataReader reader = consulta.ExecuteReader();
                if (reader.Read())
                {
                    
                    actividad.idActividad = int.Parse(reader["id"].ToString());
                    actividad.nombreActividad = reader["Nombre"].ToString();
                    actividad.descripcionActividad = reader["Descripcion"].ToString();
                    actividad.precioActividad = int.Parse(reader["precio"].ToString());
                    actividad.idCategoriaActividad = int.Parse(reader["id_categoria"].ToString());
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