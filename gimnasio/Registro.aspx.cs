using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using backEndWeb;

namespace gimnasio
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Limpiar mensajes de error
            errorCorreo.Text = "";
            errorApellidos.Text = "";
            errorNombre.Text = "";
            errorContrasena.Text = "";
            errorDni.Text = "";
            errorTarifa.Text = "";

            // Validar el correo electrónico
            if (!email.Text.Contains("@"))
            {
                errorCorreo.Text = "Por favor, ingresa un correo válido. Ejemplo: ejemplo@dominio.com.";
                return;
            }

            // Validar que se haya seleccionado una tarifa
            if (string.IsNullOrEmpty(tarifa.SelectedValue))
            {
                errorCorreo.Text = "Por favor, selecciona una tarifa. Ejemplo: 'Estudiante', 'Jubilado' o 'Standard'.";
                return;
            }

            // Validar el DNI (por ejemplo, formato "12345678A")
            string dni = DNI.Text.Trim();
            if (!Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$"))
            {
                errorDni.Text = "Por favor, ingresa un DNI válido. Ejemplo: 12345678A.";
                return;
            }

            if (string.IsNullOrEmpty(contrasena.Text))
            {
                errorContrasena.Text = "Por favor, introduce una contraseña";
                return;
            }

            if (string.IsNullOrEmpty(email.Text))
            {
                errorCorreo.Text = "Por favor, introduce un correo electrónico";
                return;
            }

            if (string.IsNullOrEmpty(DNI.Text))
            {
                errorDni.Text = "Por favor, introduce un DNI";
                return;
            }

            if (string.IsNullOrEmpty(nombre.Text))
            {
                errorNombre.Text = "Por favor, introduce un nombre";
                return;
            }

            if (string.IsNullOrEmpty(apellidos.Text))
            {
                errorApellidos.Text = "Por favor, introduce tu/s apellido/s";
                return;
            }

            // Obtener datos del formulario
            string correo = email.Text.Trim();
            string nombreUsuario = nombre.Text.Trim();
            string apellidosUsuario = apellidos.Text.Trim();
            string tarifaSeleccionada = tarifa.SelectedValue;

            // Asignar Membresía según tarifa
            int membresiaId;

            switch (tarifaSeleccionada)
            {
                case "Estudiante":
                    membresiaId = 1; // Id de la membresía "Estudiante"
                    break;
                case "Jubilado":
                    membresiaId = 2; // Id de la membresía "Jubilado"
                    break;
                case "Standard":
                    membresiaId = 3; // Id de la membresía "Standard"
                    break;
                default:
                    membresiaId = 0; // Por defecto, no asignar
                    break;
            }

            if (membresiaId == 0)
            {
                errorTarifa.Text = "La tarifa seleccionada no es válida.";
                return;
            }

            ENUsuario usuario;
            ENSocio socio;

            usuario = new ENUsuario(nombreUsuario, apellidosUsuario, dni, false, correo, contrasena.Text);
            socio = new ENSocio(correo, 0, "pendiente", membresiaId);
            
            if(usuario.createUsuario() == false)
            {   
                errorContrasena.Text = "No se ha podido crear el usuario";
            }
            else
            {
                if(socio.createSocio() == true)
                {
                    if (Request.QueryString["desde"] == "admin")
                    {
                        Response.Redirect("VerActividades.aspx");
                    }
                    else
                    {
                        Session["Email"] = correo;
                        Session["Saldo"] = 100;
                        Session["Estado"] = "Activo";
                        Session["Membresia"] = membresiaId;
                        Response.Redirect("Actividades.aspx");
                    }
                }
           
                
            }
        }
    }
}
