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
    class AsientoDAL:Operaciones
    {
        public void Insertar(EAsiento aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EAsiento aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EAsiento aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EAsiento aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EAsiento aux, string campo, string valor)
        {
            return SelectAll(aux, campo, valor);
        }

        public ArrayList LlenarComboBusqueda(EAsiento aux)
        {
            return ObtenerAtributos(aux);
        }
        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }
    }
}
