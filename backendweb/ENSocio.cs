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
        public float Saldo;
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

        public float SaldoSocio
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
            MembresiaId = 3;
        }

        public ENSocio(string co, float Saldo, string Estado, int MembresiaId)
        {
            this.correo = co;
            this.Saldo = Saldo;
            this.Estado = Estado;
            this.MembresiaId = MembresiaId;
        }

        public ENSocio(ENSocio socio)
        {
            this.correoSocio = socio.correoSocio;
            this.Saldo = socio.Saldo;
            this.Estado = socio.Estado;
            this.MembresiaId = socio.MembresiaId;
        }


        public bool createSocio()
        {
            CADSocio aux = new CADSocio();
            if (!aux.readSocio(this))
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
            if (!aux.readSocio(this))
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
