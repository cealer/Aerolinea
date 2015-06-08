using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
  public  class AeropuertoBOL
    {
        private AeropuertoDAL _aeropuertoDal = new AeropuertoDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrar(EAeropuerto aux)
        {
            _aeropuertoDal.Insertar(aux);
        }
    }
}
