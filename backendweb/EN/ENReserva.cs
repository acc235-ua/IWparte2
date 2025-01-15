using backendweb.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendweb.EN
{
    public class ENReserva
    {
        private String Correo_Socio;
        private int id_actividad;
        private String Correo_monitor;
        private DateTime fecha_alta;
        private DateTime fecha_actividad;
        private bool activa;


        public String CorreoMonitorActividad
        {
            get { return Correo_monitor; }
            set { Correo_monitor = value; }
        }

        public DateTime fechaActividad
        {
            get { return fecha_actividad; }
            set { fecha_actividad = value; }
        }
        public String CorreoSocioActividad
        {
            get { return Correo_Socio; }
            set { Correo_Socio = value; }
        }
        public int idActividad
        {
            get { return id_actividad; }
            set { id_actividad = value; }
        }

        public DateTime fechaAltaReserva
        {
            get { return fecha_alta; }
            set { fecha_alta = value; }
        }
        public bool activaReserva
        {
            get { return activa; }
            set { activa = value; }
        }

        public ENReserva()
        {

            CorreoSocioActividad = "";
            CorreoMonitorActividad = ""; 
            
            id_actividad = 0;
            fecha_alta = new DateTime();
            fecha_actividad = new DateTime();
            activa = false;



        }
        public ENReserva(String Correo_Socio ,String Correo_Monitor, int id_actividad, DateTime fecha_actividad, DateTime fecha_alta, bool activa)
        {
            this.Correo_Socio = Correo_Socio;
            this.id_actividad = id_actividad;
            this.fecha_alta = fecha_alta;
            this.activa = activa;
            this.Correo_monitor = Correo_Monitor;
            this.fecha_actividad = fecha_actividad;

        }

        public ENReserva(ENReserva reserva)
        {
            this.CorreoSocioActividad = reserva.CorreoSocioActividad;
            this.id_actividad = reserva.idActividad;
            this.fecha_alta = reserva.fechaAltaReserva;
            this.activa = reserva.activaReserva;
            this.CorreoMonitorActividad = reserva.CorreoMonitorActividad;
            this.fecha_actividad = reserva.fechaActividad;

        }

        public bool readReserva()
        {

            CADReserva aux = new CADReserva();
            return aux.readReserva(this);


        }

        public bool createReserva()
        {
            CADReserva aux = new CADReserva();
            if (aux.readReserva(this))
            {
                return false;
            }
            else
            {
                return aux.createReserva(this);
            }
        }

        public bool updateReserva()
        {
            CADReserva aux = new CADReserva();

            if (aux.readReserva(this))
            {
                return aux.updateReserva(this);
            }
            else
            {
                return false;
            }
        }

        public bool deleteReserva()
        {
            CADReserva aux = new CADReserva();

            if (aux.readReserva(this))
            {
                return aux.deleteReserva(this);
            }
            else
            {
                return false;
            }
        }
    }

}
