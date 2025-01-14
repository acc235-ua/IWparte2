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
    public class CADSocio
    {
        private string constring;
        public CADSocio()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        }

        public bool createSocio(ENSocio socio)
        {
            bool respuesta = false;

            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("INSERT INTO [dbo].[Socio] (id,Saldo,Estado,MembresiaId) + values(@id,@Saldo,@Estado,@MembresiaId", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                consulta.Parameters.AddWithValue("@Saldo", socio.Saldo);
                consulta.Parameters.AddWithValue("@Estado", socio.Estado);
                consulta.Parameters.AddWithValue("@MembresiaId", socio.MembresiaId);
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

        public bool getSocio(ENSocio socio)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Socio] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                SqlDataReader dr = consulta.ExecuteReader();
                dr.Read();
                socio.id = int.Parse(dr["id"].ToString());
                socio.Saldo = int.Parse(dr["Saldo"].ToString());
                socio.Estado = dr["Estado"].ToString();
                socio.MembresiaId = int.Parse(dr["MembresiaId"].ToString());
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

        public bool updateSocio(ENSocio socio)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Socio] SET Saldo = @Saldo, Estado = @Estado, MembresiaId = @MembresiaId WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                consulta.Parameters.AddWithValue("@Saldo", socio.Saldo);
                consulta.Parameters.AddWithValue("@Estado", socio.Estado);
                consulta.Parameters.AddWithValue("@MembresiaId", socio.MembresiaId);

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

        public bool deleteSocio(ENSocio socio)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("DELETE FROM [dbo].[Socio] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
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

        public List<ENSocio> getAllSocios()
        {
            var socios = new List<ENSocio>();

            using (SqlConnection connection = new SqlConnection(constring))
            {
                string query = @"
            SELECT 
                u.id, 
                u.Nombre, 
                u.Apellidos, 
                u.DNI, 
                u.Correo_electronico, 
                s.Saldo, 
                s.Estado,
                s.MembresiaId
            FROM 
                Usuario u
            INNER JOIN 
                Socio s ON u.id = s.id";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var socio = new ENSocio
                        {
                            id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellidos = reader.GetString(2),
                            DNI = reader.GetString(3),
                            CorreoElectronico = reader.GetString(4),
                            Saldo = reader.GetInt32(5),
                            Estado = reader.GetString(6),
                            MembresiaId = reader.GetInt32(7)
                        };

                        socios.Add(socio);
                    }
                }
            }

            return socios;
        }

        public bool cobrarSocio(ENSocio socio, int cantidad)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Socio] SET Saldo = Saldo - @cantidad WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                consulta.Parameters.AddWithValue("@cantidad", cantidad);
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

        public bool recargarSocio(ENSocio socio, int cantidad)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Socio] SET Saldo = Saldo + @cantidad WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                consulta.Parameters.AddWithValue("@cantidad", cantidad);
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

        public bool CambiarEstadoSocio(ENSocio socio, string estado)
        {
            bool respuesta = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("UPDATE [dbo].[Socio] SET Estado = @estado WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                consulta.Parameters.AddWithValue("@estado", estado);
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

        public bool readSocio(ENSocio socio)
        {
            bool encontrado = false;
            SqlConnection conec = new SqlConnection(constring);
            conec.Open();
            try
            {
                SqlCommand consulta = new SqlCommand("SELECT * FROM [dbo].[Socio] WHERE id = @id", conec);
                consulta.Parameters.AddWithValue("@id", socio.id);
                SqlDataReader dr = consulta.ExecuteReader();
                dr.Read();
                socio.id = int.Parse(dr["id"].ToString());
                socio.Saldo = int.Parse(dr["Saldo"].ToString());
                socio.Estado = dr["Estado"].ToString();
                socio.MembresiaId = int.Parse(dr["MembresiaId"].ToString());
                encontrado = true;
                dr.Close();
            }
            catch (SqlException ex)
            {
                encontrado = false;
            }
            finally
            {
                conec.Close();
            }
            return encontrado;
        }
    }

}


