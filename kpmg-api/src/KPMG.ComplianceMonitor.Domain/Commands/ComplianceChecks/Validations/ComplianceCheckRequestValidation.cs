using FluentValidation;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;

public abstract class ComplianceCheckRequestValidation<T> : AbstractValidator<T> where T : ComplianceCheckCommand
{
    protected void ValidateId()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id  é obrigatório.");
    }

    protected void Validate()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id é obrigatório.");

        RuleFor(x => x.ComplianceType)
            .NotNull().WithMessage("O tipo de conformidade é obrigatório.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descrição é obrigatória.");

        RuleFor(x => x.CheckDate)
            .NotEmpty().WithMessage("Data de verificação é obrigatória.");

        RuleFor(x => x.Result)
            .NotNull().WithMessage("Resultado de conformidade é obrigatório.");

        RuleFor(x => x.IssuesFound)
            .NotEmpty().WithMessage("Detalhes dos problemas encontrados são obrigatórios.");
    }
}