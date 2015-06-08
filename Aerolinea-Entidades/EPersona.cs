using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_Entidades
{
    public class EPersona
    {
        public int IdPersona{ get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public DateTime FecNac { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int IdTipoPersona { get; set; }
        public bool Estado { get; set; }
    }
}
