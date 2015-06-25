using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
    public class EBoleto
    {

     public int IdBoleto { get; set; }
     public int IdVuelo { get; set; }
     public int Asiento { get; set; }
     public double Costo { get; set; }
     public int IdPersona { get; set; }

    }
}
