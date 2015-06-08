using Aerolinea_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_AccesoDatos
{
   public class AeropuertoDAL:Operaciones
    {
        public void Insertar(EAeropuerto aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EAeropuerto aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EAeropuerto aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EAeropuerto aux)
        {
            Update(aux);
        }
    }
}
