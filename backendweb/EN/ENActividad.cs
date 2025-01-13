using backendweb.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backendweb.EN
{
    public class ENActividad
    {

        private int id;
        private string nombre;
        private string descripcion;
        private int precio;
        private int id_categoria;

        public int idActividad
        {
            get { return id; }
            set { id = value; }
        }
        public string nombreActividad
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string descripcionActividad
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int precioActividad
        {
            get { return precio; }
            set { precio = value; }
        }

        public int idCategoriaActividad
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        public ENActividad()
        {
            id = 0;
            nombre = "";
            descripcion = "";
            precio = 0;
            id_categoria = -1;
        }
        public ENActividad(int id, string nombre, string descripcion, int precio, int id_categoria)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.id_categoria = id_categoria;
        }

        public ENActividad(ENActividad actividad)
        {
            this.id = actividad.id;
            this.nombre = actividad.nombre;
            this.descripcion = actividad.descripcion;
            this.precio = actividad.precio;
            this.id_categoria = actividad.id_categoria;
        }

        public bool readActividad()
        {
            CADActividad aux = new CADActividad();
            //ENActividad actividad = new ENActividad();

            return aux.readActividad(this);
        }
        public bool createActividad()
        {
            CADActividad aux = new CADActividad();

            if (aux.readActividad(this))
            {
                return false;
            }
            else
            {
                return aux.createActividad(this);
            }
        }
        public bool updateActividad()
        {

            CADActividad aux = new CADActividad();

            if (aux.readActividad(this))
            {
                return aux.updateActividad(this);

            }
            else
            {
                return false;
            }
        }
        public bool deleteActividad()
        {
            CADActividad aux = new CADActividad();
            if (aux.readActividad(this))
            {
                return aux.deleteActividad(this);
            }
            else
            {
                return false;
            }
        }
    }
}
