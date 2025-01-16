using backendweb.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendweb.EN
{
    public class ENActividad_Impartida
    {
        private int id_actividad;
        private string correo_monitor;
        private DateTime fecha;
        private int huecos;
        private float precio;
        private TimeSpan hora_inicio;
        private TimeSpan hora_fin;

        public int idActividad
        {
            get { return id_actividad; }
            set { id_actividad = value; }
        }
        public string correo_monitorActividad
        {
            get { return correo_monitor; }
            set { correo_monitor = value; }
        }
        public DateTime fechaActividad
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int huecosActividad
        {
            get { return huecos; }
            set { huecos = value; }
        }

        public float precioActividad
        {
            get { return precio; }
            set { precio = value; }
        }
        public TimeSpan horaInicioActividad
        {
            get { return hora_inicio; }
            set { hora_inicio = value; }
        }

        public TimeSpan horaFinActividad
        {
            get { return hora_fin; }
            set { hora_fin = value; }
        }

        public ENActividad_Impartida()
        {
            id_actividad = 0;
            correo_monitor = "";
            fecha = new DateTime();
            huecos = 0;
            hora_inicio = new TimeSpan();
            hora_fin = new TimeSpan();
            this.precio = 0;
        }

        public ENActividad_Impartida(int id_actividad, string correo, DateTime fecha, int huecos, int precio,TimeSpan hora_inicio, TimeSpan hora_fin)
        {
            this.id_actividad = id_actividad;
            this.correo_monitor = correo;
            this.fecha = fecha;
            this.huecos = huecos;
            this.hora_inicio = hora_inicio;
            this.hora_fin = hora_fin;
            this.precio = precio;
        }

        public ENActividad_Impartida(ENActividad_Impartida actividad)
        {
            this.id_actividad = actividad.id_actividad;
            this.correo_monitor = actividad.correo_monitor;
            this.fecha = actividad.fecha;
            this.huecos = actividad.huecos;
            this.hora_inicio = actividad.hora_inicio;
            this.hora_fin = actividad.hora_fin;
            this.precio = actividad.precio;
        }

        public bool readActividad()
        {
            CADActividad_Impartida aux = new CADActividad_Impartida();
            if (aux.readActividad_Impartida(this))
            {
                return true;
            }
            return false;
        }

        public bool createActividad()
        {
            CADActividad_Impartida aux = new CADActividad_Impartida();
            if (this.readActividad())
            {
                return false;
            }
            else
            {
                return aux.createActividadImpartida(this);
            }
        }

        public bool updateActividad()
        {
            CADActividad_Impartida aux = new CADActividad_Impartida();
            if (this.readActividad())
            {
                return aux.updateActividadImpartida(this);
            }
            else
            {
                return false;
            }
        }

        public bool deleteActividad()
        {
            CADActividad_Impartida aux = new CADActividad_Impartida();
            if (this.readActividad())
            {
                return aux.deleteActividadImpartida(this);
            }
            else
            {
                return false;
            }
        }

        //recibe un array de tuplas para llenarlo, declararlo vacío ya que su contenido previo se pierde para llenarlo
        public bool listarActividadesImpartidas(ref (int, string, DateTime)[] actividades_Impartidas) {

            CADActividad_Impartida aux = new CADActividad_Impartida();
            return aux.listarActividadesImpartidas(ref actividades_Impartidas);
            //return true o false según si falla
            
        }
    }
}
