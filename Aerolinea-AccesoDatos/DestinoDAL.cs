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
  public class DestinoDAL:Operaciones
    {

        public void Insertar(EDestino aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EDestino aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EDestino aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EDestino aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EDestino aux, string campo, string valor)
        {
            return SelectAll(aux, campo, valor);
        }

        public ArrayList LlenarComboBusqueda(EDestino aux)
        {
            return ObtenerAtributos(aux);
        }
       
      public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }

    }
}
