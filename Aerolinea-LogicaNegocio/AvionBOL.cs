using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System.Data;
using System.Collections;
using FluentValidation.Results;
using Aerolinea_LogicaNegocio.RulesValidation;
namespace Aerolinea_LogicaNegocio
{
   public class AvionBOL
    {
        private AvionDAL _avionDal = new AvionDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();
 
        readonly AvionValidator _AvionValidator = new AvionValidator();
        
        public void Registrar(EAvion avion)
        {
            ValidationResult result = _AvionValidator.Validate(avion);
            if (result.IsValid)
            {
                _avionDal.Insertar(avion); 
            }
            else
            {
                var errores = result.Errors;

                foreach (var item in result.Errors)
                {
                    stringBuilder.AppendLine(item.ErrorMessage);
                }
                throw new CustomException(stringBuilder.ToString());
            }
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

       public void Modificar(EAvion avion){
           _avionDal.Update(avion);
       }
        public DataTable ObtenerTodos(EAvion avion) {
            return _avionDal.SelectAll(avion);
        }

        public DataTable ObtenerCondicion(EAvion avion,string campo,string valor) { 
        return _avionDal.SelectAll(avion,campo,valor);
        }


    }
}