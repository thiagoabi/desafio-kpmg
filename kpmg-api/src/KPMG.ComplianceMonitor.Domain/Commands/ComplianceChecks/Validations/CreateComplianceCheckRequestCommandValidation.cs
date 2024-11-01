using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;

public class CreateComplianceCheckRequestCommandValidation : ComplianceCheckRequestValidation<CreateComplianceCheckRequestCommand>
{
    public CreateComplianceCheckRequestCommandValidation()
    {
        Validate();
    }
}
