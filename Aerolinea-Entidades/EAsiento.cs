using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
   public class EAsiento
    {
        public int IdAsiento { get; set; }
        public int IdPasajero { get; set; }
        public string Destino { get; set; }
        public string Procedencia { get; set; }
        public bool Estado { get; set; }
        public double Costo { get; set; }


    }
}
