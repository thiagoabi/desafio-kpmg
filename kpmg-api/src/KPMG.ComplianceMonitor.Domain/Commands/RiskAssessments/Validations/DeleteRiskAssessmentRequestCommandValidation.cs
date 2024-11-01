using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;

public class DeleteRiskAssessmentRequestCommandValidation : RiskAssessmentRequestValidation<DeleteRiskAssessmentRequestCommand>
{
    public DeleteRiskAssessmentRequestCommandValidation()
    {
        ValidateId();
    }
}