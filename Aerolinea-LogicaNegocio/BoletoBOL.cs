using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
  public class BoletoBOL
    {

      private BoletoDAL _boletoDal = new BoletoDAL();

      public void Registrar(EBoleto aux)
      {
          _boletoDal.Insertar(aux);
      }

      public ArrayList AsientoDisponibles(int id)
      {
          EBoleto aux = new EBoleto();
          ArrayList lista = new ArrayList();
          var ocupados = _boletoDal.ObtenerVueloAsientos(id);
          for (int i = 0; i < ocupados.Rows.Count; i++)
          {
              lista.Add((int)ocupados.Rows[i].ItemArray[0]);
          }
          return lista;
      }

      public DataTable obtenerTodos(EBoleto aux, DateTime fec1, DateTime fec2)
      {
          return _boletoDal.ObtenerTodos(aux,fec1,fec2);
         // return _boletoDal.SelectAll(aux);
      }

      public void Eliminar(EBoleto aux, int id)
      {
          _boletoDal.Delete(aux, id);
      }

      public void Modificar(EBoleto aux)
      {
          _boletoDal.Update(aux);
      }

      public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
      {
          return _boletoDal.ObtenerPorId(Entitie, id);
      }
    }
}
