using backEndWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace backEndWeb
{
    public class ENSocio
    {
        public int id;
        public int Saldo;
        public string Estado;

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




    }
}
