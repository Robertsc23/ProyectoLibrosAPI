using FluentValidation;
using Proyecto.Application.DTOs.Libros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Validators
{
    public class LibroBodyDTOValidator : AbstractValidator<LibroBodyDTO>
    {
        public LibroBodyDTOValidator()
        {
            RuleFor(x => x.Isbn)
                .NotEmpty().WithMessage("El ISBN es obligatorio.")
                .MaximumLength(20).WithMessage("El ISBN no debe exceder los 20 caracteres.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(200).WithMessage("El título no debe exceder los 200 caracteres.");

            RuleFor(x => x.Autores)
                .NotEmpty().WithMessage("Los autores son obligatorios.");

            RuleFor(x => x.Edicion)
                .NotEmpty().WithMessage("La edición es obligatoria.");

            RuleFor(x => x.Anio)
                .InclusiveBetween(1900, DateTime.Now.Year + 5)
                .WithMessage("El año debe estar entre 1900 y el actual +5 años.");

            RuleFor(x => x.IdEditorial)
                .NotEmpty().WithMessage("El Id del editorial es obligatorio.")
                .GreaterThan(0).WithMessage("Debe seleccionar una editorial válida.");
        }
    }
}
