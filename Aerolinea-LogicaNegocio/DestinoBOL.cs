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
   public class DestinoBOL
    {
        private DestinoDAL _destinoDal = new DestinoDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void Registrar(EDestino aux)
        {
            _destinoDal.Insertar(aux);
        }

        public ArrayList LlenarCombo(EDestino aux)
        {
            return _destinoDal.LlenarComboBusqueda(aux);
        }

        public void Eliminar(EDestino aux, int id)
        {
            _destinoDal.Delete(aux, id);
        }

        public DataTable ObtenerTodos(EDestino aux)
        {
            return _destinoDal.SelectAll(aux);
        }



        public DataTable ObtenerCondicion(EDestino aux, string campo, string valor)
        {
            return _destinoDal.SelectAll(aux, campo, valor);
        }

        public void Modificar(EDestino aux)
        {
            _destinoDal.Update(aux);
        }
       
        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _destinoDal.ObtenerPorId(Entitie, id);
        }

    }
}
