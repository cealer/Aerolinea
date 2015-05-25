using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea_Entidades;
using System.Data;
using System.Collections;
namespace Aerolinea_AccesoDatos
{
   public class AvionDAL:Operaciones
    {

       public void Insertar(EAvion aux) {
           Insert(aux);
       }

       public DataTable ObtenerTodos(EAvion aux)
       {
         return SelectAll(aux);
       }

       public void Eliminar(EAvion aux, int id)
       {
           Delete(aux,id);
       }

       public void Modificar(EAvion aux) {
           Update(aux);
       }

       public DataTable ObtenerCondicional (EAvion aux,string campo,string valor) {
          return SelectAll(aux, campo, valor);
       }

       public ArrayList LlenarComboBusqueda(EAvion aux) {
           return ObtenerAtributos(aux);
       }

       public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie,int id)
       {
           return GetByid(Entitie, id);
       }

       //public void Insertar(EAvion aux)
       //{
       //    SqlCommand cmd = new SqlCommand();
       //    cmd.Connection = cn;
       //    cmd.CommandType = CommandType.StoredProcedure;
       //    cmd.CommandText = "SP_Avion_Insertar";
       //    cmd.Parameters.AddWithValue("@nomAero", aux.Aerolinea);
       //    cmd.Parameters.AddWithValue("@modelo", aux.Modelo);
       //    cmd.Parameters.AddWithValue("@capacidad", aux.Capacidad);
       //    cmd.Parameters.AddWithValue("@longitud", aux.Longitud);
       //    cmd.Parameters.AddWithValue("@envergadura", aux.Envergadura);
       //    cmd.Parameters.AddWithValue("@despliege", aux.Despliege);
       //    cmd.Parameters.AddWithValue("@salida", aux.Salida);
       //    cmd.Parameters.AddWithValue("@sanitarios", aux.Sanitarios);
       //    Conectar();
       //    cmd.ExecuteNonQuery();
       //    DesConectar();
       //}






        }
    }
