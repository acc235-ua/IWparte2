using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENMonitor
    {
        public string correo;
        public string especialidad;
        public float salario;
        public string telefono;

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string CorreoElectronico { get; set; }

        public string correoMonitor
        {
            get { return correo; }
            set { correo = value; }
        }
        public string especialidadMonitor
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public float salarioMonitor
        {
            get { return salario; }
            set { salario = value; }
        }

        public string telefonoMonitor
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public ENMonitor()
        {
            correoMonitor = "";
            especialidad = "";
            salario = 0;
            telefono = "";
        }

        public ENMonitor(string correo, string especialidad, float salario, string telefono)
        {
            correoMonitor = correo;
            this.especialidad = especialidad;
            this.salario = salario;
            this.telefono = telefono;
        }

        public ENMonitor(ENMonitor monitor)
        {
            this.correo = monitor.correo;
            this.especialidad = monitor.especialidad;
            this.salario = monitor.salario;
            this.telefono = monitor.telefono;
        }

        public bool createMonitor()
        {
            CADMonitor aux = new CADMonitor();
            if (aux.readMonitor(this))
            {
                return aux.createMonitor(this);
            }
            else
            {
                return false;
            }
        }

        public bool deleteMonitor()
        {
            CADMonitor aux = new CADMonitor();
            if (aux.readMonitor(this))
            {
                return aux.deleteMonitor(this);
            }
            else
            {
                return false;
            }

        }

        public bool updateMonitor()
        {
            CADMonitor aux = new CADMonitor();
            if (aux.readMonitor(this))
            {
                return aux.updateMonitor(this);
            }
            else
            {
                return false;
            }
        }

        public List<ENMonitor> getAllMonitores()
        {
            CADMonitor aux = new CADMonitor();
            return aux.getAllMonitores();
        }

    }
}
