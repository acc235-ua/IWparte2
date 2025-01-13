using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENMonitor
    {

        public int id;
        public string especialidad;
        public float salario;
        public string telefono;

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string CorreoElectronico { get; set; }

        public int idMonitor
        {
            get { return id; }
            set { id = value; }
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
            id = 0;
            especialidad = "";
            salario = 0;
            telefono = "";
        }

        public ENMonitor(int id, string especialidad, float salario, string telefono)
        {
            this.id = id;
            this.especialidad = especialidad;
            this.salario = salario;
            this.telefono = telefono;
        }

        public ENMonitor(ENMonitor monitor)
        {
            this.id = monitor.id;
            this.especialidad = monitor.especialidad;
            this.salario = monitor.salario;
            this.telefono = monitor.telefono;
        }




    }
}
