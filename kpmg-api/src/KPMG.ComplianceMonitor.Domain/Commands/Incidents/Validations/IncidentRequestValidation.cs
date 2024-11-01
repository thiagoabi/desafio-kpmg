using FluentValidation;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public abstract class IncidentRequestValidation<T> : AbstractValidator<T> where T : IncidentCommand
{
    protected void ValidateId()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id  é obrigatório.");
    }

    protected void ValidateUser()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Usuário é obrigatório.");
    }

    protected void ValidateResolution()
    {
        RuleFor(x => x.IsResolved)
            .NotEmpty().WithMessage("Informe se o incidente foi resolvido ou não.");

        When(x => x.IsResolved.HasValue && x.IsResolved.Value, () =>
        {
            RuleFor(x => x.ResolutionDate)
                .NotEmpty().WithMessage("Data de Resolução é obrigatório se o incidente está resolvido.");

            RuleFor(x => x.ResolutionDetails)
                .NotEmpty().WithMessage("Detalhes da Resolução é obrigatório se o incidente está resolvido.");
        });
    }

    protected void Validate()
    {
        RuleFor(x => x.IncidentType).NotNull().WithMessage("Tipo de incidente não pode ser nula.")
            .IsInEnum()
            .Must(x => x != EnumIncidentType.None)
            .WithMessage("Tipo de incidente inválido.");

        RuleFor(x => x.SeverityLevel).NotNull().WithMessage("Nível de severidade não pode ser nula.")
            .IsInEnum()
            .Must(x => x != EnumSeverityLevel.None)
            .WithMessage("Nível de severidade inválido.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descrição é obrigatória.");

        RuleFor(x => x.IncidentDate)
            .NotEmpty().WithMessage("Data do incidente é obrigatória.");
    }
}
