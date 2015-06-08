using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
  public  class TipoPersonaBOL
    {
        private TipoPersonaDAL _tipoPersonaDal = new TipoPersonaDAL();

        public void Registrar(ETipoPersona persona)
        {
            _tipoPersonaDal.Insertar(persona);
        }

        public DataTable ObtenerTodos(ETipoPersona persona)
        {
            return _tipoPersonaDal.SelectAll(persona);
        }


    }
}
