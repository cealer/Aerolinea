using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Aerolinea_AccesoDatos
{
  public  class Operaciones:BDComun
    {
      //Ejecutar Procedimientos almancenados
      
      //Generador de consultas
      string getTable<unknowtype>(unknowtype Entities)
      {
       return Regex.Replace(Entities.GetType().Name, "E", "");
      }

      public void Insert<unknowtype>(unknowtype Entities){
            string consulta = "";
            string Table = getTable(Entities);
            var atributos = Entities.GetType().GetMethods();
            var getAtributos = atributos.Where(x => x.Name.Contains("get"));
            StringBuilder dbAtri=new StringBuilder();
            int max=getAtributos.Count();
            foreach (var item in getAtributos)
            {
                max--;
                if (!item.Name.Contains("Id" + Table))
                {
                   
                    if (max == 0)
                    {
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "@"));
                        dbAtri.Append(")");
                    }
                    else
                    {
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "@") + ",");
                    }    
                }
            }
             consulta="insert into "+Table+" values ("+dbAtri;
           SqlCommand cmd = new SqlCommand(consulta, cn);
           foreach (var item in getAtributos)
           {
               if (!item.Name.Contains("Id" + Table))
               {
                   cmd.Parameters.AddWithValue(Regex.Replace(item.Name, "get_", "@"), Entities.GetType().GetProperty(Regex.Replace(item.Name, "get_", "")).GetValue(Entities));
               }
           }
           Conectar();
           cmd.ExecuteNonQuery();
           DesConectar();
        }
        
      public void Update<unknowtype>(unknowtype Entities)
        {
            string consulta = "";
            string Table = getTable(Entities);
            var atributos = Entities.GetType().GetMethods();
            var getAtributos = atributos.Where(x => x.Name.Contains("get"));
            StringBuilder dbAtri = new StringBuilder();
            int max = getAtributos.Count();
            foreach (var item in getAtributos)
            {
                max--;
                if (!item.Name.Contains("Id"+Table))
                {
                    if (max == 0)
                    {
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "") + "=");
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "@"));
                    }
                    else
                    {
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "") + "=");
                        dbAtri.Append(Regex.Replace(item.Name, "get_", "@") + ",");
                    }
                }
            }
            consulta = "update " + Table + " set " + dbAtri + " where Id" + Table + " = @" + "Id" + Table;
            SqlCommand cmd = new SqlCommand(consulta, cn);
            foreach (var item in getAtributos)
            {
                cmd.Parameters.AddWithValue(Regex.Replace(item.Name, "get_", "@"), Entities.GetType().GetProperty(Regex.Replace(item.Name, "get_", "")).GetValue(Entities));

            }
            Conectar();
            cmd.ExecuteNonQuery();
            DesConectar();
        }
  
      public ArrayList ObtenerAtributos<unknowtype>(unknowtype Entities)
      {
          ArrayList listaCampos = new ArrayList();
          string Table = getTable(Entities);
          var atributos = Entities.GetType().GetMethods();
          var getAtributos = atributos.Where(x => x.Name.Contains("get"));
          foreach (var item in getAtributos)
          {
              if (!item.Name.Contains("Id" + Table))
              {
                  listaCampos.Add(Regex.Replace(item.Name, "get_", ""));
              }
          }
          return listaCampos;
      }

      //Consultas 
      public DataTable Select<unknowtype>(unknowtype Entities, string campo)
      {
          string consulta = "";
          string Table = getTable(Entities);
          consulta = "select "+campo +" from " + Table;
          SqlDataAdapter adapter = new SqlDataAdapter(consulta, cn);
          DataSet ds = new DataSet();
          adapter.Fill(ds, Table);
          return ds.Tables[0];
      }

      public DataTable SelectAll<unknowtype>(unknowtype Entities,string campo,string valor)
      {
          string consulta = "";
          string Table = getTable(Entities);
          consulta = "select * from " + Table+" where "+campo+" like @valor "+"+ '%'";
          SqlDataAdapter adapter = new SqlDataAdapter(consulta, cn);
          adapter.SelectCommand.Parameters.AddWithValue("@valor",valor);
          DataSet ds = new DataSet();
          adapter.Fill(ds,Table);
          return ds.Tables[0];
      }

      public DataTable SelectAll<unknowtype>(unknowtype Entities)
      {
          StringBuilder condiciones = new StringBuilder();
          string Table = getTable(Entities);
          condiciones.Append("select * from " + Table);
          SqlDataAdapter adapter = new SqlDataAdapter(condiciones.ToString(), cn);
          DataSet ds = new DataSet();
          adapter.Fill(ds, Table);
          return ds.Tables[0];
      }

      //Genera los inner join
      public DataTable SelectAll<unknowtype>(unknowtype Entities,string Buscar)
      {
          StringBuilder innerjoin = new StringBuilder();
          string Table = getTable(Entities);
          var atributos = Entities.GetType().GetMethods();
          var getAtributos = atributos.Where(x => x.Name.Contains("get"));
          int max = getAtributos.Count();
          foreach (var item in getAtributos)
          {
              if (!item.Name.Contains("Id" + Table) && item.Name.Contains("Id"))
              {
                  innerjoin.Append(" INNER JOIN " + Regex.Replace(item.Name, "get_Id", "") + " ON " + Table + "." + Regex.Replace(item.Name, "get_", "") + " = " + Regex.Replace(item.Name, "get_Id", "") + "." + Regex.Replace(item.Name, "get_", ""));
              }
          }
          string consulta = "Select " + Buscar + " From " + Table + innerjoin.ToString();
          SqlDataAdapter adapter = new SqlDataAdapter(consulta, cn);
          DataSet ds = new DataSet();
          adapter.Fill(ds, Table);
          return ds.Tables[0];
      }


      public DataTable SelectAllCondicional<unknowtype>(unknowtype Entities, string Buscar,string where)
      {
          StringBuilder innerjoin = new StringBuilder();
          string Table = getTable(Entities);
          var atributos = Entities.GetType().GetMethods();
          var getAtributos = atributos.Where(x => x.Name.Contains("get"));
          int max = getAtributos.Count();
          foreach (var item in getAtributos)
          {
              if (!item.Name.Contains("Id" + Table) && item.Name.Contains("Id"))
              {
                  innerjoin.Append(" INNER JOIN " + Regex.Replace(item.Name, "get_Id", "") + " ON " + Table + "." + Regex.Replace(item.Name, "get_", "") + " = " + Regex.Replace(item.Name, "get_Id", "") + "." + Regex.Replace(item.Name, "get_", ""));
              }
          }
          string consulta = "Select " + Buscar + " From " + Table + innerjoin.ToString()+where;
          SqlDataAdapter adapter = new SqlDataAdapter(consulta, cn);
          DataSet ds = new DataSet();
          adapter.Fill(ds, Table);
          return ds.Tables[0];
      }


      public void Delete<unknowtype>(unknowtype Entities,int id) {
          string Table = getTable(Entities);
          string consulta = "DELETE FROM "+ Table +" WHERE Id"+ Table +"= @Id"+Table;
          SqlCommand cmd = new SqlCommand(consulta,cn);
          cmd.Parameters.AddWithValue("@Id"+ Table,id);
          Conectar();
          cmd.ExecuteNonQuery();
          DesConectar();
        }

      public unknowtype GetByid<unknowtype>(unknowtype Entities, int id)
      {
          string Table = getTable(Entities);
          var atributos = Entities.GetType().GetMethods();
          var getAtributos = atributos.Where(x => x.Name.Contains("get"));
          string consulta = "SELECT * FROM "+Table+" WHERE Id"+Table+"= @id"+Table;
          SqlCommand cmd = new SqlCommand(consulta,cn);
          cmd.Parameters.AddWithValue("@id" + Table,id);
          Conectar();
          var list= cmd.ExecuteReader();
          int c = 0;
          while (list.Read())
	    {
	      foreach (var item in getAtributos)
               {
                  Entities.GetType().GetProperty(Regex.Replace(item.Name, "get_", "")).SetValue(Entities,list.GetValue(c));
                  c++;      
          }
	    }
          DesConectar();
          return Entities;
      }


      
    }
}
