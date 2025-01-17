using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using backEndWeb;

namespace gimnasio
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarUsuarios();
            }
        }

        // Mostrar la lista de usuarios
        private void MostrarUsuarios()
        {
            (string, string)[] usuarios = new (string, string)[0];  // Tupla con dos elementos: correo y nombre
            ENUsuario enUsuario = new ENUsuario();

            bool exito = enUsuario.listarUsuarios(ref usuarios);

            if (exito && usuarios.Length > 0)
            {
                
                gvUsuarios.DataSource = usuarios.Select(ai => new
                {
                    Correo_electronico = ai.Item1,
                    Nombre = ai.Item2,
                }).ToList();
             
                gvUsuarios.DataBind(); 
            }
            else
            {
                Mensaje.Text = "No hay Usuarios disponibles.";
            }
        }



        // Método para manejar el evento de editar o eliminar
        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string correo = e.CommandArgument.ToString();
            if (e.CommandName == "Editar")
            {
                // Cargar los detalles del usuario para editar
                CargarDetallesUsuario(correo);
            }
            else if (e.CommandName == "Borrar")
            {
                if (!string.IsNullOrEmpty(correo))
                {
                    BorrarUsuario(correo);
                }
                else
                {
                    Response.Write("<script>alert('No se pudo obtener el correo del usuario.');</script>");
                }
            }

        }

        
        private void CargarDetallesUsuario(string correo)
        {
            
            ENUsuario usuario = new ENUsuario();
            usuario.correoUser = correo;

            if (usuario.readUsuario())
            {
                string nombre = usuario.nombreUser;
                string apellidos = usuario.apellidosUser;
                string dni = usuario.dniUser;
                bool esAdmin = usuario.esAdminUser;
                string contrasena = usuario.contrasenaUser;

                // Rellenar los campos del formulario
                txtCorreo.Text = correo;
                txtNombre.Text = nombre;
                txtApellidos.Text = apellidos;
                txtDNI.Text = dni;
                chkEsAdmin.Checked = esAdmin;
                txtContrasena.Text = contrasena;
            }

            
        }

        // Eliminar usuario
        private void BorrarUsuario(string correo)
        {
            ENUsuario usuario = new ENUsuario
            {
                correoUser = correo
            };

            if (usuario.deleteUsuario())
            {
                // Mensaje de éxito
                Response.Write("<script>alert('Usuario eliminado con éxito.');</script>");

                
                gvUsuarios.DataSource = null;
                gvUsuarios.DataBind();

                
                MostrarUsuarios();
            }
            else
            {
                // Si ocurre un error al eliminar
                Response.Write("<script>alert('Error al eliminar el usuario.');</script>");
            }
        }

        // Crear o editar usuario
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string dni = txtDNI.Text;
            bool esAdmin = chkEsAdmin.Checked;
            string contrasena = txtContrasena.Text;

            ENUsuario usuario = new ENUsuario
            {
                correoUser = correo,
                nombreUser = nombre,
                apellidosUser = apellidos,
                dniUser = dni,
                esAdminUser = esAdmin,
                contrasenaUser = contrasena
            };

            if (usuario.updateUsuario()) // Si es una actualización
            {
                MostrarUsuarios();
                lblMensaje.Text = "Usuario actualizado con éxito.";
            }
            else
            {
                if (usuario.createUsuario()) // Si es un nuevo usuario
                {
                    MostrarUsuarios();
                    lblMensaje.Text = "Usuario creado con éxito.";
                }
                else
                {
                    lblMensaje.Text = "Error al guardar el usuario.";
                }
            }
        }

        protected void btnCobrar(object sender, EventArgs e)
        {

        }
    }
}