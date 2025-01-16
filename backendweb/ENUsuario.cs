using backEndWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace backEndWeb
{
    public class ENUsuario
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string dni;
        private Boolean esAdmin;
        private string correo;
        private string contrasena;

        public int idUser
        {
            get { return id; }
            set { id = value; }
        }
        public string nombreUser
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string apellidosUser
        {
            get { return apellidos; }
            set { apellidos = value; }

        }
        public string dniUser
        {
            get { return dni; }
            set { dni = value; }
        }
        public string correoUser
        {
            get { return correo; }
            set { correo = value; }

        }

        public string contrasenaUser
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public Boolean esAdminUser
        {
            get { return esAdmin; }
            set { esAdmin = value; }

        }
        public ENUsuario()
        {
            CADUsuario aux = new CADUsuario();
            this.id = aux.obtenerId();
            this.dni = "";
            this.nombre = "";
            this.apellidos = "";
            this.contrasena = "";
            this.correo = "";
            this.esAdmin = false;



        }

        public ENUsuario(string nombre, string apellidos, string dni, bool esAdmin, string correo, string contrasena)
        {
            CADUsuario aux = new CADUsuario();

            this.id = aux.obtenerId();

            this.nombre = nombre;
            this.apellidos = apellidos;
            this.dni = dni;
            this.esAdmin = esAdmin;
            this.correo = correo;
            this.contrasena = contrasena;

        }

        public ENUsuario(ENUsuario e)
        {
            this.id = e.id;
            this.nombre = e.nombre;
            this.dni = e.dni;
            this.esAdmin = e.esAdmin;
            this.correo = e.correo;
            this.apellidos = e.apellidos;
            this.contrasena = e.contrasena;
        }



        public bool readUsuario()
        {
            CADUsuario aux = new CADUsuario();
            if (aux.readUsuario(this) == "")
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool createUsuario()
        {
            CADUsuario aux = new CADUsuario();
            ENUsuario usu = new ENUsuario(this);
            if (usu.readUsuario())
            {
                //ya esxiste
                return false;
            }
            else
            {
                aux.createUsuario(this);
                return true;
            }



        }

        public bool updateUsuario()
        {
            CADUsuario aux = new CADUsuario();

            if (this.readUsuario())
            {
                aux.updateUsuario(this);
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool deleteUsuario()
        {
            CADUsuario aux = new CADUsuario();
            //ENUsuario usu = new ENUsuario(this);
            if (this.readUsuario())
            {
                aux.deleteUsuario(this);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool listarUsuarios(ref (int, string)[] usuarios) // ESPERAMOS UN ARRAY VACÍO PARA LLENAR CON TUPLAS 
                                                                 //EN EL CAD SE BORRA CONTENIDO ACTUAL ARRAY
        {
            CADUsuario aux = new CADUsuario();
            if (aux.listarUsuarios(ref usuarios))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}