using FluentValidation;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;

public abstract class RiskAssessmentRequestValidation<T> : AbstractValidator<T> where T : RiskAssessmentCommand
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

        RuleFor(x => x.RiskCategory)
            .NotNull().WithMessage("Categoria de risco é obrigatória.");

        RuleFor(x => x.RiskDescription)
            .NotEmpty().WithMessage("Descrição do risco é obrigatória.");

        RuleFor(x => x.ImpactLevel)
            .NotNull().WithMessage("Nível de impacto é obrigatório.");

        RuleFor(x => x.Likelihood)
            .NotNull().WithMessage("Probabilidade é obrigatória.");

        RuleFor(x => x.MitigationPlan)
            .NotEmpty().WithMessage("O plano de mitigação é obrigatório.");

        RuleFor(x => x.AssessmentDate)
            .NotEmpty().WithMessage("Data de avaliação é obrigatória.");

        RuleFor(x => x.Status)
            .NotNull().WithMessage("Status de avaliação de risco é obrigatório.");
    }
}