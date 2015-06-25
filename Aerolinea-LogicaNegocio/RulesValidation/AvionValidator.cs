using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class AvionValidator:AbstractValidator<EAvion>
    {
        public AvionValidator()
        {
            RuleFor(x => x.Aerolinea)
    .NotEmpty().WithMessage("La Aerolinea no puede estar en blanco.")
    .Must(x => x.Length >= 6).WithMessage("La Aerolinea debe tener almenos 6 digitos caracteres.");
            RuleFor(x => x.Capacidad).GreaterThan(0).WithMessage("La capacidad debe ser mayor a 0");
            RuleFor(x => x.Despliegue).GreaterThan(0).WithMessage("El Despliegue debe ser mayor a 0");
            RuleFor(x => x.Envergadura).GreaterThan(0).WithMessage("La Envergadura debe ser mayor a 0");
            RuleFor(x => x.Longitud).GreaterThan(0).WithMessage("La Longitud debe ser mayor a 0");
            RuleFor(x => x.Salida).GreaterThan(0).WithMessage("La salida debe ser mayor a 0");
        }
    }
}
