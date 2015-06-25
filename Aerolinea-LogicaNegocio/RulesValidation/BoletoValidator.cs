using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class BoletoValidator : AbstractValidator<EBoleto>
    {
        public BoletoValidator()
        {
            RuleFor(x => x.IdPersona).GreaterThan(0).WithMessage("Se debe elegir un pasajero");
            RuleFor(x => x.Costo).GreaterThan(0).WithMessage("El costo debe ser mayor a 0");
        }
    }
}
