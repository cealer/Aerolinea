using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System.Data;
using System.Collections;
namespace Aerolinea_LogicaNegocio
{
   public class AvionBOL
    {
        private AvionDAL _avionDal = new AvionDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();
       
        public void Registrar(EAvion avion)
        {
                _avionDal.Insertar(avion);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie,int id){
           return _avionDal.ObtenerPorId(Entitie,id);
       }

        public ArrayList LlenarCombo(EAvion avion) {
          return _avionDal.LlenarComboBusqueda(avion);
        }

        public void Eliminar(EAvion avion,int id) {
            _avionDal.Delete(avion, id);
        }

        public DataTable ObtenerTodos(EAvion avion) {
            return _avionDal.SelectAll(avion);
        }

        public DataTable ObtenerCondicion(EAvion avion,string campo,string valor) { 
        return _avionDal.SelectAll(avion,campo,valor);
        }

       public void Modificar(EAvion avion){
           _avionDal.Update(avion);
       }
    }
}