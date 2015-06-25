using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class DestinoValidator : AbstractValidator<EDestino>
    {
        public DestinoValidator()
        {
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.IdDestino)
                .NotNull().WithMessage("El Número del Destino no puede ser nulo");
            RuleFor(x => x.Destino)
                .NotEmpty().WithMessage("El Destino no puede estar en blanco.")
                .Must(x => x.Length > 1).WithMessage("El Destino debe tener más de 1 caracteres.")
                .Must(x => x.Length < 51).WithMessage("El Destino debe tener menos de 51 caracteres.");
            RuleFor(x => x.Costo1)
                .GreaterThan(0).WithMessage("El precio de la primera clase debe ser mayor que 0");
            RuleFor(x => x.Costo2)
    .GreaterThan(0).WithMessage("El precio normal debe ser mayor que 0");
        }
    }
}
