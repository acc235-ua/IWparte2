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
    public class CADUsuario

    {
        private string constring;
        public CADUsuario()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();

        }

        /// Obtiene un nuevo Id para introducir a la BBDD, es decir,
        /// suma 1 al ultimo id introducido a la bbdd, si esta vacio devuelve 1
        /// </summary>
        /// <returns></returns>
        public int obtenerId()
        {
            int idNuevo = 1;
            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("Select max(Id) maxId, Count(Id) numRows from [dbo].[comentario]", conec);

                SqlDataReader dr = consulta.ExecuteReader();

                dr.Read();

                if (int.Parse(dr["numRows"].ToString()) != 0)
                {
                    idNuevo = int.Parse(dr["maxId"].ToString()) + 1;
                    dr.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("The operation has failed.Error: {0}", ex.Message);
            }
            finally
            {
                conec.Close();
            }

            return idNuevo;
        }


        public string createUsuario(ENUsuario user)
        {
            string respuesta = "";

            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();
                SqlCommand consulta = new SqlCommand("Insert INTO [dbo].[Usuario] " +
                    "(id,Apellidos,DNI,Es_admin,Correo_electronico,Contrasena)" +
                    "values (@id,@apellidos,@dni,@esAdmin,@correo,@contrasena)", conec);

                consulta.Parameters.Add("@id", SqlDbType.Int).Value = user.idUser;
                consulta.Parameters.Add("@apellidos", SqlDbType.Text).Value = user.apellidosUser;
                consulta.Parameters.Add("@dni", SqlDbType.Text).Value = user.dniUser;
                consulta.Parameters.Add("@esAdmin", SqlDbType.Bit).Value = user.esAdminUser;
                consulta.Parameters.Add("@correo", SqlDbType.Text).Value = user.correoUser;
                consulta.Parameters.Add("@contrasena", SqlDbType.Text).Value = user.contrasenaUser;

                consulta.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                respuesta = ex.Message;
                Console.WriteLine("Fallo en CAD al añadir user a la BD", respuesta);
            }
            finally { conec.Close(); }
            //si respuesta es "" , código se ejecuta correcto
            return respuesta;
        }


        public string readUsuario(ENUsuario user)
        {
            string respuesta = "";

            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();
                SqlDataAdapter consulta = new SqlDataAdapter("SELECT * FROM [dbo].[Usuario] WHERE id =" + user.idUser, conec);

                DataSet tablaDatos = new DataSet();
                consulta.Fill(tablaDatos);

                if (tablaDatos.Tables[0].Rows.Count > 0)
                {
                    // user.nombreUser = tablaDatos.Tables[0].Rows[0]["nombre"].ToString();
                    user.apellidosUser = tablaDatos.Tables[0].Rows[0]["Apellidos"].ToString();
                    user.dniUser = tablaDatos.Tables[0].Rows[0]["DNI"].ToString();
                    user.esAdminUser = Convert.ToBoolean(tablaDatos.Tables[0].Rows[0]["Es_admin"]);
                    user.correoUser = tablaDatos.Tables[0].Rows[0]["Correo_electronico"].ToString();
                    user.contrasenaUser = tablaDatos.Tables[0].Rows[0]["Contrasena"].ToString();

                }
                else
                {
                    respuesta = "EMPTY";
                }

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                Console.Write("Error en CAD leyendo usuario:", respuesta);
            }
            finally { conec.Close(); }
            return respuesta;
        }


        public string deleteUsuario(ENUsuario user)
        {

            string respuesta = "";

            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();

                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Usuario] WHERE id = " + user.idUser, conec);
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                Console.WriteLine("Error en CAD eliminando user:", respuesta);

            }
            finally { conec.Close(); }
            return respuesta;

        }


        public string updateUsuario(ENUsuario user)
        {

            string respuesta = "";

            SqlConnection conec = new SqlConnection(constring);
            try
            {
                conec.Open();

                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Usuario] SET, " +
                    "Apellidos=@apellidosuser, DNI= @dniuser, Es_admin=@esadminuser, " +
                    "Correo_electronico= @correouser, Contrasena= @contrasenaUser" +
                    "WHERE id= @iduser", conec);

                consulta.Parameters.Add("@iduser", SqlDbType.Int).Value = user.idUser;
                consulta.Parameters.Add("@apellidosuser", SqlDbType.Text).Value = user.apellidosUser;
                consulta.Parameters.Add("@nombreuser", SqlDbType.Text).Value = user.nombreUser;
                consulta.Parameters.Add("@dniuser", SqlDbType.Text).Value = user.dniUser;
                consulta.Parameters.Add("@esadminuser", SqlDbType.Bit).Value = user.esAdminUser;
                consulta.Parameters.Add("@correouser", SqlDbType.Text).Value = user.correoUser;
                consulta.Parameters.Add("@contrasenauser", SqlDbType.Text).Value = user.contrasenaUser;

                consulta.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
                Console.WriteLine("Error en CAD al actualizar user: ", respuesta);
            }
            finally { conec.Close(); }
            return respuesta;

        }

    }
}
