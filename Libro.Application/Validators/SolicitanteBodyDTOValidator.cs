using FluentValidation;
using Proyecto.Application.DTOs.Solicitantes;


namespace Proyecto.Application.Validators
{
    public class SolicitanteBodyDTOValidator : AbstractValidator<SolicitanteBodyDTO>
    {
        public SolicitanteBodyDTOValidator()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio.")
                .NotNull().WithMessage("El nombre completo es obligatorio."); 

            RuleFor(x => x.DocumentoIdentidad)            
                .NotEmpty().WithMessage("El documento de identidad no puede estar vacío.")
                .NotNull().WithMessage("El documento de identidad es obligatorio.")
                .MaximumLength(20);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email no puede estar vacío.")
                .NotNull().WithMessage("El email es obligatorio.")
                .EmailAddress().WithMessage("Debe ser un correo electrónico válido.");

            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El telefono no puede estar vacío.")
                .MaximumLength(20).WithMessage("El teléfono no debe exceder 20 caracteres.");
        }
    }
}
