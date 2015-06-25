using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class TipoPersonaValidator : AbstractValidator<ETipoPersona>
    {
        public TipoPersonaValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.IdTipoPersona)
                .NotNull().WithMessage("El Número de Persona no puede ser nulo");

            RuleFor(x => x.Tipo)
                .NotEmpty().WithMessage("El Tipo de persona no puede estar en blanco.")
                .Must(x => x.Length > 1).WithMessage("El Tipo de persona debe tener mas de 1 caracteres")
                .Must(x => x.Length < 51).WithMessage("El Tipo de persona debe tener menos de 51 caracteres");
        }
    }
}
