using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;
using System.Web.UI;
using backendweb;
using backendweb.EN;
using System.Linq;
using System.Web.UI.WebControls;
using backEndWeb;

namespace gimnasio
{
    public partial class Actividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarActividadesImpartidas();
            }
        }

        private void MostrarActividadesImpartidas()
        {
            (int, string, string, DateTime)[] actividadesImpartidas = Array.Empty<(int, string, string, DateTime)>();

            ENActividad_Impartida actividadImpartidaEN = new ENActividad_Impartida();
            bool exito = actividadImpartidaEN.listarActividadesImpartidas(ref actividadesImpartidas);

            if (exito && actividadesImpartidas.Length > 0)
            {
                // Rellena el GridView con los datos obtenidos
                gvActividadesImpartidas.DataSource = actividadesImpartidas.Select(ai => new
                {
                    IdActividad = ai.Item1,
                    CorreoMonitor = ai.Item2,
                    NombreActividad = ai.Item3,
                    Fecha = ai.Item4.ToString("yyyy-MM-dd")
                }).ToList();
                gvActividadesImpartidas.DataBind();  // Esto asegura que se actualice el DataSource
            }
            else
            {
                lblMensaje.Text = "No hay actividades impartidas disponibles.";
            }
        }

        protected void gvActividadesImpartidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                
                string[] argumentos = e.CommandArgument.ToString().Split('|');
                int idActividad = int.Parse(argumentos[0]);
                string correoMonitor = argumentos[1]; 
                DateTime fecha = DateTime.Parse(argumentos[2]);
                string correoUsuario = Session["CorreoUsuario"] as string;
                if (e.CommandName == "Inscribir")
                {
                    // Inscribir actividad
                    InscribirActividad(idActividad, correoMonitor, fecha, correoUsuario);
                   
                    // Refrescar Saldo
                    ENSocio socio = new ENSocio(correoUsuario, 50, "activo", 1);
                    socio.cobrarSocio(5);
                    
                }
            }
        }

        protected void InscribirActividad(int actividad, string monitor, DateTime fecha, string usuario)
        {
            ENReserva reserva = new ENReserva(usuario, monitor, actividad, fecha, DateTime.Today, true);

            bool reservado = reserva.createReserva();
        }


    }
}
