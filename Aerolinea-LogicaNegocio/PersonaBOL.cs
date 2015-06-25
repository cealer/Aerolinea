using Aerolinea_AccesoDatos;
using Aerolinea_Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Aerolinea_LogicaNegocio.RulesValidation;

namespace Aerolinea_LogicaNegocio
{
   public class PersonaBOL
    {
      
        readonly PersonaValidator _personaValidator = new PersonaValidator();

        public readonly StringBuilder str = new StringBuilder();

        private PersonaDAL _personaDal = new PersonaDAL();

        public void Registrar(EPersona aux)
        {
            ValidationResult result = _personaValidator.Validate(aux);

            if (result.IsValid)
            {

                _personaDal.Insertar(aux);
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
        public void Modificar(EPersona aux)
        {
            _personaDal.Update(aux);
        }

        public DataTable ObtenerTodos(EPersona aux,string buscar)
        {
            return _personaDal.SelectAll(aux,buscar);
        }

        public void Eliminar(EPersona aux, int id)
        {
            _personaDal.Delete(aux, id);
        }

        public ArrayList LlenarCombo(EPersona aux)
        {
            return _personaDal.LlenarComboBusqueda(aux);
        }

        public DataTable ObtenerCondicion(EPersona aux, string campo, string valor,string datos)
        {
            return _personaDal.SelectAllCondicional(aux, campo, valor,datos);
        }

        public int ObtenerIdPasajero() { 
        return _personaDal.ObtenerMaxId();
        }

        public unknowtype ObtenerPorId<unknowtype>(unknowtype Entitie, int id)
        {
            return _personaDal.ObtenerPorId(Entitie, id);
        }
   
   }
}
