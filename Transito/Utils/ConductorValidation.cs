using FluentValidation;
using Transito.DTO;

namespace Transito.Utils
{
    public class ConductorValidation : AbstractValidator<ConductorDTO>
    {
        public ConductorValidation()
        {
            RuleFor(a => a.Nombre).NotEmpty().WithMessage("Nombre NO puede ser vacio");
            RuleFor(b => b.Telefono).Length(10).WithMessage("Numero Telefono debe tener 10 caracteres");
            RuleFor(c => c.Apellidos).NotEmpty().WithMessage("Apellido es Obligatorio");
            RuleFor(user => user.Nombre).NotEqual(user => user.Apellidos).WithMessage("Nombre y apellido no pueden ser iguales");
            RuleFor(customer => customer.Email).EmailAddress();
        }
    }
}