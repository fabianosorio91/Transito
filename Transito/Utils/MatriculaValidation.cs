using FluentValidation;
using Transito.DTO;

namespace Transito.Utils
{
    public class MatriculaValidation: AbstractValidator<MatriculaDTO>
    {
    
        public MatriculaValidation()
        {
            RuleFor(s => s.ValidaHasta).NotEmpty().WithMessage("Nombre Obligatorio");
            // RuleFor(a=> a.ValidaHasta).Length(2, 50).WithMessage("El nombre debe tener una longitud entre 2 y 50 caracteres");
          
        }
    }
}
