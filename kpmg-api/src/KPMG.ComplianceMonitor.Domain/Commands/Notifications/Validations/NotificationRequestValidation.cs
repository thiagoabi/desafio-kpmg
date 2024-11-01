using FluentValidation;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public abstract class NotificationRequestValidation<T> : AbstractValidator<T> where T : IncidentCommand
{
    protected void ValidateId()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage("Id  é obrigatório.");
    }
}
