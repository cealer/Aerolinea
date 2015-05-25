using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
  public class VueloBOL
    {
      private VueloDAL _vueloDal = new VueloDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrar(EVuelo aux)
        {
            _vueloDal.Insertar(aux);
        }

        public ArrayList LlenarCombo(EVuelo aux)
        {
            return _vueloDal.LlenarComboBusqueda(aux);
        }

        public void Eliminar(EVuelo aux, int id)
        {
            _vueloDal.Delete(aux, id);
        }

        public DataTable ObtenerTodos(EVuelo aux,string buscar)
        {
            return _vueloDal.SelectAll(aux,buscar);
        }

        public DataTable ObtenerCondicion(EVuelo aux, string campo, string valor)
        {
            return _vueloDal.SelectAll(aux, campo, valor);
        }

        public void Modificar(EVuelo aux)
        {
            _vueloDal.Update(aux);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _vueloDal.ObtenerPorId(Entitie, id);
        }

    }
}
