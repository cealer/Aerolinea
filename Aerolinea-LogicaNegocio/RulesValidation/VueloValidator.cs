using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class VueloValidator : AbstractValidator<EVuelo>
    {
        public VueloValidator()
        {
            RuleFor(x => x.IdVuelo)
            .NotNull().WithMessage("El Número del vuelo no puede ser nulo");
            RuleFor(x => x.IdAvion)
          .NotNull().WithMessage("El Número del avión no puede ser nulo");
            RuleFor(x => x.IdDestino)
          .NotNull().WithMessage("El Número del destino no puede ser nulo");

        }

    }
}
