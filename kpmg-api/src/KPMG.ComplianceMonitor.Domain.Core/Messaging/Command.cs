using FluentValidation.Results;
using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Core.Messaging;

public abstract class Command : Message, IRequest<ValidationResult>
{
    public Guid? Id { get; protected set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command()
    {
        ValidationResult = new ValidationResult();
    }

    public virtual bool IsValid()
    {
        return ValidationResult.IsValid;
    }
}