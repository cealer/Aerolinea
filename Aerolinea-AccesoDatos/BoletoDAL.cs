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
   public class BoletoDAL:Operaciones
    {
        public void Insertar(EBoleto aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EBoleto aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EBoleto aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EBoleto aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EBoleto aux, string campo, string valor)
        {
            return SelectAll(aux, campo, valor);
        }

        public ArrayList LlenarComboBusqueda(EBoleto aux)
        {
            return ObtenerAtributos(aux);
        }
        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }
   }
}
