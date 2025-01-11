using backEndWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            set {  esAdmin = value; }

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

        public ENUsuario(int id, string nombre, string apellidos, string dni, bool esAdmin, string correo, string contrasena)
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
    }
}