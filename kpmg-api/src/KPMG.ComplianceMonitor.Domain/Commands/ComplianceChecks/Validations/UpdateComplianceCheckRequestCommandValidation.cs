using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;

public class UpdateComplianceCheckRequestCommandValidation : ComplianceCheckRequestValidation<UpdateComplianceCheckRequestCommand>
{
    public UpdateComplianceCheckRequestCommandValidation()
    {
        ValidateId();
        Validate();
    }
}