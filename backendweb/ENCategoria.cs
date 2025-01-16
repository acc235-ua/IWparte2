using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENCategoria
    {
        public int id;
        public string Nombre;

        public int idCategoria
        {
            get { return id; }
            set { id = value; }
        }

        public string nameCategoria
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public ENCategoria()
        {
            id = 0;
            Nombre = "";
        }

        public ENCategoria(int id, string name)
        {
            this.id = id;
            this.Nombre = name;
        }

        public ENCategoria(ENCategoria enCategoria)
        {
            this.id = enCategoria.id;
            this.Nombre = enCategoria.Nombre;
        }

        public bool createCategoria()
        {
            CADCategoria aux = new CADCategoria();
            if (aux.readCategoria(this))
            {
                return false;
            }
            else
            {
                return aux.createCategoria(this);
            }
        }

        public bool deleteCategoria()
        {
            CADCategoria aux = new CADCategoria();
            if (aux.readCategoria(this))
            {
                return aux.deleteCategoria(this);
            }
            else
            {
                return false;
            }

        }

        public bool updateCategoria()
        {
            CADCategoria aux = new CADCategoria();
            if (aux.readCategoria(this))
            {
                return aux.updateCategoria(this);
            }
            else
            {
                return false;
            }




        }
    }
}
