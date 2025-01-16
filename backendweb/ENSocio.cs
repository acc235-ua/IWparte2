using backEndWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENSocio
    {
        public string correo;
        public int Saldo;
        public string Estado;
        public int MembresiaId;

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        //public string CorreoElectronico { get; set; }

        public string correoSocio
        {
            get { return correo; }
            set { correo = value; }
        }

        public int SaldoSocio
        {
            get { return Saldo; }
            set { Saldo = value; }
        }


        public string EstadoSocio
        {
            get { return Estado; }
            set { Estado = value; }
        }

        public int MembresiaIdSocio
        {
            get { return MembresiaId; }
            set { MembresiaId = value; }
        }

        public ENSocio()
        {
            correoSocio = "";
            Saldo = 0;
            Estado = "";
        }

        public ENSocio(string co, int Saldo, string Estado)
        {
            this.correoSocio = co;
            this.Saldo = Saldo;
            this.Estado = Estado;
        }

        public ENSocio(ENSocio socio)
        {
            this.correoSocio = socio.correoSocio;
            this.Saldo = socio.Saldo;
            this.Estado = socio.Estado;
        }


        public bool createSocio()
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.createSocio(this);
            }
            else
            {
                return false;
            }
        }

        public bool getSocio()
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.readSocio(this);
            }
            else
            {
                return false;

            }
        }

        public bool deleteSocio()
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.deleteSocio(this);
            }
            else
            {
                return false;

            }
        }

        public bool updateSocio()
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.updateSocio(this);
            }
            else
            {
                return false;
            }
        }

        public List<ENSocio> readAllSocio()
        {
            CADSocio aux = new CADSocio();
            return aux.getAllSocios();
        }

        public bool cobrarSocio(int cantidad)
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.cobrarSocio(this, cantidad);
            }
            else
            {
                return false;
            }
        }

        public bool recargarSocio(int cantidad)
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.recargarSocio(this, cantidad);
            }
            else
            {
                return false;
            }
        }

        public bool cambiarEstadoSocio(string estado)
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.cambiarEstadoSocio(this, estado);
            }
            else
            {
                return false;
            }
        }

        public bool cambiarMembresiaSocio(int idMembresia)
        {
            CADSocio aux = new CADSocio();
            if (aux.readSocio(this))
            {
                return aux.cambiarMembresiaSocio(this, idMembresia);
            }
            else
            {
                return false;
            }
        }
    }
}
