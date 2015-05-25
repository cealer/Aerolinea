using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
    public class EVuelo
    {
        public int IdVuelo { get; set; }
        public int IdAvion { get; set; }
        public DateTime Salida { get; set; }
        public int IdDestino { get; set; }
        
    }
}
