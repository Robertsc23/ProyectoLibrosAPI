using FluentValidation;
using Proyecto.Application.DTOs.Editoriales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Application.Validators
{
    public class EditorialBodyDTOValidator : AbstractValidator<EditorialBodyDTO>
    {
        public EditorialBodyDTOValidator()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("El codigo de la editorial es obligatorio.")
                .MaximumLength(10).WithMessage("El codigo no debe exceder los 10 caracteres.");


            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la editorial es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre no debe exceder los 150 caracteres.");

            
        }
    }
}
