using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_AccesoDatos
{
  public  class PersonaDAL:Operaciones
    {
        public void Insertar(EPersona aux)
        {
            Insert(aux);
        }

        public DataTable ObtenerTodos(EPersona aux)
        {
            return SelectAll(aux);
        }

        public void Eliminar(EPersona aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EPersona aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EPersona aux, string campo, string valor,string dato)
        {
            return SelectAllCondicional(aux, campo, valor,dato);
        }

        public ArrayList LlenarComboBusqueda(EPersona aux)
        {
            return ObtenerAtributos(aux);
        }
       
      public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }

        public int ObtenerMaxId() {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "pMaxIdPasajero";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cn;
            cn.Open();
            int r =Convert.ToInt32(cmd.ExecuteScalar());
            cn.Close();
            return r;
        }
    }
}
