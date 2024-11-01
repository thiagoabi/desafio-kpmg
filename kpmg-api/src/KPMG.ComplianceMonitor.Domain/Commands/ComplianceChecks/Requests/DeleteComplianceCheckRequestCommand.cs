using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

public class DeleteComplianceCheckRequestCommand : ComplianceCheckCommand
{
    public DeleteComplianceCheckRequestCommand(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new DeleteComplianceCheckRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
