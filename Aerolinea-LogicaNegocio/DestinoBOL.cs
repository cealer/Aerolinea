using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using Aerolinea_LogicaNegocio.RulesValidation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Aerolinea_LogicaNegocio
{
    public class DestinoBOL
    {
        private DestinoDAL _destinoDal = new DestinoDAL();

        public readonly StringBuilder stringBuilder = new StringBuilder();

        readonly DestinoValidator _DestinoValidator = new DestinoValidator();
        
        public void Registrar(EDestino aux)
        {
            ValidationResult result = _DestinoValidator.Validate(aux);
            if (result.IsValid)
            {
                _destinoDal.Insertar(aux); 
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

        public ArrayList LlenarCombo(EDestino aux)
        {
            return _destinoDal.LlenarComboBusqueda(aux);
        }

        public void Eliminar(EDestino aux, int id)
        {
            _destinoDal.Delete(aux, id);
        }

        public DataTable ObtenerTodos(EDestino aux)
        {
            return _destinoDal.SelectAll(aux);
        }



        public DataTable ObtenerCondicion(EDestino aux, string campo, string valor)
        {
            return _destinoDal.SelectAll(aux, campo, valor);
        }

        public void Modificar(EDestino aux)
        {
            _destinoDal.Update(aux);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _destinoDal.ObtenerPorId(Entitie, id);
        }

    }
}
