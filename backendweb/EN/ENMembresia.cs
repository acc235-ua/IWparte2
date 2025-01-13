using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENMembresia
    {
        public int id;
        public string Descripcion;
        public string Tipo;
        public float Precio;


        public int idMembresia
        {
            get { return id; }
            set { id = value; }
        }

        public string DescripcionMembresia
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string TipoMembresia
        {
            get { return Tipo; }
            set { Tipo = value; }
        }

        public float PrecioMembresia
        {
            get { return Precio; }
            set { Precio = value; }
        }

        public ENMembresia()
        {
            id = 0;
            Descripcion = "";
            Tipo = "";
            Precio = 0;
        }

        public ENMembresia(int id, string Descripcion, string Tipo, float Precio)
        {
            this.id = id;
            this.Descripcion = Descripcion;
            this.Tipo = Tipo;
            this.Precio = Precio;
        }

        public ENMembresia(ENMembresia enMembresia)
        {
            this.id = enMembresia.id;
            this.Descripcion = enMembresia.Descripcion;
            this.Tipo = enMembresia.Tipo;
            this.Precio = enMembresia.Precio;
        }





    }
}
