﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using backendweb.EN;
using backEndWeb;

namespace gimnasio
{
    public partial class VerActividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarActividades();
                CargarMonitores();
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
                    NombreActividad = ai.Item2,
                    CorreMonitor = ai.Item3,
                    Fecha = ai.Item4.ToString("yyyy-MM-dd")
                }).ToList();
                gvActividadesImpartidas.DataBind();
            }
            else
            {
                lblMensaje.Text = "No hay actividades impartidas disponibles.";
            }
        }


        private void CargarActividades()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            string query = "SELECT Id, Nombre FROM Actividad";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlIdActividad.DataSource = reader;
                    ddlIdActividad.DataTextField = "Nombre";
                    ddlIdActividad.DataValueField = "Id";
                    ddlIdActividad.DataBind();
                }
            }
        }

        private void CargarMonitores()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            string query = "SELECT Correo_electronico FROM Monitor";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlCorreoMonitor.DataSource = reader;
                    ddlCorreoMonitor.DataTextField = "Correo_electronico";
                    ddlCorreoMonitor.DataValueField = "Correo_electronico";
                    ddlCorreoMonitor.DataBind();
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string idActividad = ddlIdActividad.SelectedValue;
            string correoMonitor = ddlCorreoMonitor.SelectedValue;
            string fecha = txtFecha.Text.Trim();
            string horaInicio = txtHoraInicio.Text.Trim();
            string horaFin = txtHoraFin.Text.Trim();
            string huecos = txtHuecos.Text.Trim();
            string precio = txtPrecio.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
            string query = "INSERT INTO Actividad_Impartida (Id_Actividad, Correo_Monitor, Fecha, Hora_Inicio, Hora_Fin, Huecos, Precio) " +
                           "VALUES (@Id_Actividad, @Correo_Monitor, @Fecha, @Hora_Inicio, @Hora_Fin, @Huecos, @Precio)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id_Actividad", idActividad);
                    cmd.Parameters.AddWithValue("@Correo_Monitor", correoMonitor);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@Hora_Inicio", horaInicio);
                    cmd.Parameters.AddWithValue("@Hora_Fin", horaFin);
                    cmd.Parameters.AddWithValue("@Huecos", huecos);
                    cmd.Parameters.AddWithValue("@Precio", precio);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Mostrar mensaje de éxito o redirigir a otra página
            Response.Write("<script>alert('Actividad registrada con éxito.');</script>");
        }

        protected void gvActividadesImpartidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                // Dividir el argumento para obtener los valores de la clave primaria
                string[] argumentos = e.CommandArgument.ToString().Split('|');
                int idActividad = int.Parse(argumentos[0]);
                string correoMonitor = argumentos[1];  // Ahora obtenemos el correo del monitor
                DateTime fecha = DateTime.Parse(argumentos[2]);

                if (e.CommandName == "Editar")
                {
                    // Cargar datos en el formulario para edición
                    CargarDatosActividad(idActividad, correoMonitor, fecha);
                }
                else if (e.CommandName == "Borrar")
                {
                    // Eliminar actividad
                    BorrarActividad(idActividad, correoMonitor, fecha);

                    // Refrescar listado
                    MostrarActividadesImpartidas();
                }
            }
        }



        private void CargarDatosActividad(int idActividad, string correoMonitor, DateTime fecha)
        {
            ENActividad_Impartida actividad = new ENActividad_Impartida
            {
                idActividad = idActividad,
                correo_monitorActividad = correoMonitor,  // Asignamos el correo del monitor
                fechaActividad = fecha
            };

            if (actividad.readActividad())
            {
                // Llenar el formulario con los datos
                ddlIdActividad.SelectedValue = actividad.idActividad.ToString();
                ddlCorreoMonitor.SelectedValue = actividad.correo_monitorActividad;  // Rellenar el combo con el correo del monitor
                txtFecha.Text = actividad.fechaActividad.ToString("yyyy-MM-dd");
                txtHoraInicio.Text = actividad.horaInicioActividad.ToString("HH:mm");
                txtHoraFin.Text = actividad.horaFinActividad.ToString("HH:mm");
                txtHuecos.Text = actividad.huecosActividad.ToString();
                txtPrecio.Text = actividad.precioActividad.ToString("F2");

                // Guardar identificadores en campos ocultos
                hiddenIdActividad.Value = idActividad.ToString();
                hiddenCorreoMonitor.Value = correoMonitor;
                hiddenFecha.Value = fecha.ToString("yyyy-MM-dd");
            }
        }

        private void BorrarActividad(int idActividad, string correoMonitor, DateTime fecha)
        {
            ENActividad_Impartida actividad = new ENActividad_Impartida
            {
                idActividad = idActividad,
                correo_monitorActividad = correoMonitor,
                fechaActividad = fecha
            };

            if (actividad.deleteActividad())
            {
                Response.Write("<script>alert('Actividad eliminada con éxito.');</script>");
            }
            else
            {
                Response.Write("<script>alert('Error al eliminar la actividad.');</script>");
            }
        }



        protected void btnCobrar(object sender, EventArgs e)
        {

        }
    }
}