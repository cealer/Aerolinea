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
    public class BoletoDAL : Operaciones
    {
        public void Insertar(EBoleto aux)
        {
            Insert(aux);
        }

        public DataTable Obtener(EBoleto aux, string campo)
        {
            return Select(aux, campo);
        }

        public DataTable ObtenerTodos(EBoleto aux, DateTime fec1, DateTime fec2)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("ListarBoletos", cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@fec1",fec1);
            da.SelectCommand.Parameters.AddWithValue("@fec2", fec2);
            da.Fill(dt);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void Eliminar(EBoleto aux, int id)
        {
            Delete(aux, id);
        }

        public void Modificar(EBoleto aux)
        {
            Update(aux);
        }

        public DataTable ObtenerCondicional(EBoleto aux, string campo, string valor,string dato)
        {
            return SelectAllCondicional(aux, campo, valor,dato);
        }


        public ArrayList LlenarComboBusqueda(EBoleto aux)
        {
            return ObtenerAtributos(aux);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return GetByid(Entitie, id);
        }

        public DataTable ObtenerVueloAsientos(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SP_Obtener_Vuelo",cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            da.Fill(dt);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

    }
}
