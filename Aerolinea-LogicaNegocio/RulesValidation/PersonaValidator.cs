using Aerolinea_Entidades;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aerolinea_LogicaNegocio.RulesValidation
{
    class PersonaValidator:AbstractValidator<EPersona>
    {
        public PersonaValidator()
        {
        //CascadeMode, determina si la ejecucion de las reglas deberia de continuar al fallar una de ellas
            //o detener la validacion del resto cuando alguna falle
            //
            //Aqui le indicamos que la validacion continue aun y cuando alguna de ellas falle
            CascadeMode = CascadeMode.Continue;

            RuleFor(x => x.IdPersona)
                .NotNull().WithMessage("El Número de Persona no puede ser nulo");

            RuleFor(x => x.Nombres)
                .NotEmpty().WithMessage("El Nombre no puede estar en blanco.")
                .Must(x => x.Length > 1).WithMessage("El nombre debe tener mas de 1 caracteres")
                .Must(x => x.Length < 51).WithMessage("El nombre debe tener menos de 51 caracteres");

            RuleFor(x => x.Apellidos)
                .NotEmpty().WithMessage("El Apellido no puede estar en blanco.")
                .Must(x => x.Length > 1).WithMessage("El apellido de tener mas de 1 caracteres")
                .Must(x => x.Length < 51).WithMessage("El apellido debe tener menos de 51 caracteres");
            RuleFor(x => x.Dni)
                .NotEmpty().WithMessage("El DNI no puede estar en blanco.")
                .Must(x => x.Length > 1).WithMessage("El DNI de tener mas de 1 caracteres")
                .Must(x => x.Length <=8).WithMessage("El DNI debe tener  de 8 caracteres");
            //
            //FechaNacimiento
            //* El valor debe ser menor a la fecha del SO
            //
            RuleFor(x => x.FecNac)
                .LessThan(DateTime.Today.Date).WithMessage("La Fecha de Nacimiento no es valida");
    }
    }
}
