using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using Aerolinea_LogicaNegocio.RulesValidation;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
  public class VueloBOL
    {
      private VueloDAL _vueloDal = new VueloDAL();
      readonly VueloValidator _vueloValidator = new VueloValidator();

      public readonly StringBuilder str = new StringBuilder();


        public void Registrar(EVuelo aux)
        {
            ValidationResult result = _vueloValidator.Validate(aux);

            if (result.IsValid)
            {
                _vueloDal.Insertar(aux); 
            }
            else
            {
                var errores = result.Errors;

                foreach (var item in result.Errors)
                {
                    str.AppendLine(item.ErrorMessage);
                }
                throw new CustomException(str.ToString());
            }

        }

        public ArrayList LlenarCombo(EVuelo aux)
        {
            return _vueloDal.LlenarComboBusqueda(aux);
        }

        public void Eliminar(EVuelo aux, int id)
        {
            _vueloDal.Delete(aux, id);
        }

        public DataTable ObtenerTodos(EVuelo aux,string buscar)
        {
            return _vueloDal.SelectAll(aux,buscar);
        }

        public DataTable ObtenerCondicion(EVuelo aux, string campo, string valor)
        {
            return _vueloDal.SelectAll(aux, campo, valor);
        }

        public void Modificar(EVuelo aux)
        {
            _vueloDal.Update(aux);
        }

        public DataTable ObtenerBuscar(EVuelo aux, string campos, string where,string datos)
        {
            return _vueloDal.SelectAllCondicional(aux, campos, where,datos);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _vueloDal.ObtenerPorId(Entitie, id);
        }

    }
}