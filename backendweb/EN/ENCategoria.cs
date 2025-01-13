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


    }
}
