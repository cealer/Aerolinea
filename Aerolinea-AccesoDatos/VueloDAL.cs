using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_AccesoDatos
{
  public  class VueloDAL:Operaciones
    {
        public void Insertar(EVuelo aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EVuelo aux)
        {
            return SelectAll(aux);
        }

        public DataTable ObtenerTodos(EVuelo aux,string buscar)
        {
            return SelectAll(aux,buscar);
        }

        public void Eliminar(EVuelo aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EVuelo aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EVuelo aux, string campo, string valor)
        {
            return SelectAll(aux, campo, valor);
        }

        public ArrayList LlenarComboBusqueda(EVuelo aux)
        {
            return ObtenerAtributos(aux);
        }
        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }
    }
}
