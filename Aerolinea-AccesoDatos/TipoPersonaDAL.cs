using Aerolinea_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_AccesoDatos
{
    public class TipoPersonaDAL : Operaciones
    {
        public void Insertar(ETipoPersona aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(ETipoPersona aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(ETipoPersona aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(ETipoPersona aux)
        {
            Update(aux);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }
    }
}
