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
        public int id;
        public int Saldo;
        public string Estado;
        public int MembresiaId;

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string CorreoElectronico { get; set; }

        public int idSocio
        {
            get { return id; }
            set { id = value; }
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
            id = 0;
            Saldo = 0;
            Estado = "";
        }

        public ENSocio(int id, int Saldo, string Estado)
        {
            this.id = id;
            this.Saldo = Saldo;
            this.Estado = Estado;
        }

        public ENSocio(ENSocio socio)
        {
            this.id = socio.id;
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
    }
}
