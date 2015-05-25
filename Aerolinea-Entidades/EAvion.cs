using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
   public class EAvion
    {
        public int IdAvion { get; set; }
        public string Aerolinea { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }
        public double Longitud { get; set; }
        public double Envergadura { get; set; }
        public double Despliegue { get; set; }
        public int Salida { get; set; }
        public int Sanitarios { get; set; }
    }
}
