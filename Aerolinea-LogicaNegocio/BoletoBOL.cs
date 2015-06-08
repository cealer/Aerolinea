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

      /*
         for (int j = 0; j < ocupados.Rows.Count; j++)
                {
                    if (aux.Numero == (int)ocupados.Rows[j].ItemArray[0])
                    {
                        aux.Estado = EstadoAsiento.Ocupado;
                    }
                }
      */
      public ArrayList AsientoDisponibles()
      {
          EBoleto aux = new EBoleto();
          ArrayList lista = new ArrayList();
          var ocupados = _boletoDal.Obtener(aux, "Asiento");
          for (int i = 0; i < ocupados.Rows.Count; i++)
          {
              lista.Add((int)ocupados.Rows[i].ItemArray[0]);    
          }
          return lista;
      }
    }
}
