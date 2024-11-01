using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;

public class DeleteComplianceCheckRequestCommandValidation : ComplianceCheckRequestValidation<DeleteComplianceCheckRequestCommand>
{
    public DeleteComplianceCheckRequestCommandValidation()
    {
        ValidateId();
    }
}