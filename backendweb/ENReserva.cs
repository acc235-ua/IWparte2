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
        private int id_socio;
        private int id_actividad;
        private int id_monitor;
        private DateTime fecha_alta;
        private DateTime fecha_actividad;
        private bool activa;


        public int idMonitor
        {
            get { return id_monitor; }
            set { id_monitor = value; }
        }

        public DateTime fechaActividad
        {
            get { return fecha_actividad; }
            set { fecha_actividad = value; }
        }
        public int idSocio
        {
            get { return id_socio; }
            set { id_socio = value; }
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
            id_socio = 0;
            id_actividad = 0;
            fecha_alta = new DateTime();
            activa = false;
        }
        public ENReserva(int id_socio, int id_monitor, int id_actividad, DateTime fecha_actividad, DateTime fecha_alta, bool activa)
        {
            this.id_socio = id_socio;
            this.id_actividad = id_actividad;
            this.fecha_alta = fecha_alta;
            this.activa = activa;
            this.id_monitor = id_monitor;
            this.fecha_actividad = fecha_actividad;

        }

        public ENReserva(ENReserva reserva)
        {
            this.id_socio = reserva.idSocio;
            this.id_actividad = reserva.idActividad;
            this.fecha_alta = reserva.fechaAltaReserva;
            this.activa = reserva.activaReserva;
            this.id_monitor = reserva.idMonitor;
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
