using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;

public class UpdateRiskAssessmentRequestCommandValidation : RiskAssessmentRequestValidation<UpdateRiskAssessmentRequestCommand>
{
    public UpdateRiskAssessmentRequestCommandValidation()
    {
        ValidateId();
        Validate();
    }
}