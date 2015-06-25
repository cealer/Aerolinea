using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using Aerolinea_LogicaNegocio.RulesValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio
{
    public class TipoPersonaBOL
    {


        readonly TipoPersonaValidator _tipopersonaValidator = new TipoPersonaValidator();

        public readonly StringBuilder str = new StringBuilder();

        private TipoPersonaDAL _tipoPersonaDal = new TipoPersonaDAL();

        public void Registrar(ETipoPersona persona)
        {
            ValidationResult result = _tipopersonaValidator.Validate(persona);

            if (result.IsValid)
            {
                _tipoPersonaDal.Insertar(persona);
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

        public DataTable ObtenerTodos(ETipoPersona persona)
        {
            return _tipoPersonaDal.SelectAll(persona);
        }

        public void Eliminar(ETipoPersona aux, int id)
        {
            _tipoPersonaDal.Delete(aux, id);
        }

        public void Modificar(ETipoPersona aux)
        {
            _tipoPersonaDal.Update(aux);
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _tipoPersonaDal.ObtenerPorId(Entitie, id);
        }

    }
}
