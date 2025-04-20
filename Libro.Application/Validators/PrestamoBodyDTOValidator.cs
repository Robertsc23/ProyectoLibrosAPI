using FluentValidation;
using Proyecto.Application.DTOs.Prestamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Validators
{
    public class PrestamoBodyDTOValidator : AbstractValidator<PrestamoBodyDTO>
    {
        public PrestamoBodyDTOValidator()
        {
            RuleFor(x => x.IdSolicitante)
                .NotNull().WithMessage("El id del solicitante es obligatorio")
                .GreaterThan(0).WithMessage("Debe seleccionar un solicitante valido.");

            RuleFor(x => x.FechaDevolucion)
                .NotNull().WithMessage("La fecha de devolucion es obligatoria.")
                .Must(BeAValidDate).WithMessage("La fecha de devolución debe ser valida y mayor que hoy.");
        }

        private bool BeAValidDate(DateTime? fecha)
        {
            if (!fecha.HasValue) return false;
            return fecha.Value.Date >= DateTime.Today;
        }
    }
}
