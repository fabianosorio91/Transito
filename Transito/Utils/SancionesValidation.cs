using FluentValidation;
using Transito.DTO;

namespace Transito.Utils
{
    public class SancionesValidation : AbstractValidator<SancionesDTO>
    {
        public SancionesValidation()
        {
            RuleFor(s => s.Sancion).NotEmpty().WithMessage("Nombre Obligatorio");
            RuleFor(a => a.Observacion).Length(2, 50).WithMessage("{PropertyName} tiene {TotalLength} letras. Debe tener una longitud entre {MinLength} y {MaxLength} letras.");
        }
    }
}
