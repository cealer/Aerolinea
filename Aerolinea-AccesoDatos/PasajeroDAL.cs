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
    class PasajeroDAL:Operaciones
    {
        public void Insertar(EPasajero aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EPasajero aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EPasajero aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EPasajero aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EPasajero aux, string campo, string valor)
        {
            return SelectAll(aux, campo, valor);
        }

        public ArrayList LlenarComboBusqueda(EPasajero aux)
        {
            return ObtenerAtributos(aux);
        }
        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }
    }
}
