using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class UsuarioValidator : AbstractValidator<EUsuario>
    {
        public UsuarioValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.IdUsuario)
                .NotNull().WithMessage("El Número del usuario no puede ser nulo");
            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("El usuario no puede estar en blanco.")
                .Must(x => x.Length >= 6).WithMessage("El usuario debe tener almenos 6 digitos caracteres.");
            RuleFor(x => x.Pass)
    .NotEmpty().WithMessage("La contraseña no puede estar en blanco.")
    .Must(x => x.Length >= 6).WithMessage("La contraseña debe tener almenos 6 digitos caracteres.");
        }
    }
}
