using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
    public class EUsuario
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Pass { get;  set; }
        public bool Privilegios { get; set; }
    }
}
