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
    public class UsuarioBOL
    {
        private UsuarioDAL _usuarioDal = new UsuarioDAL();
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        readonly UsuarioValidator _usuarioValidator = new UsuarioValidator();

        public void Registrar(EUsuario aux)
        {
            ValidationResult result = _usuarioValidator.Validate(aux);

            if (result.IsValid)
            {
                _usuarioDal.Insertar(aux);
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

        public string GenerarHash(string pass)
        {
            return _usuarioDal.getPassword(pass);
        }

        public bool validarUsuario(string pass, string hash)
        {
            return _usuarioDal.validarPassword(pass, hash);
        }

        public DataTable Buscar(string usuario)
        {
            EUsuario aux = new EUsuario();
            return _usuarioDal.BuscarUsuario(aux, usuario);
        }
        public int MaxUsuario() {
            return _usuarioDal.ObtenerMaxId();
        }
    }
}
