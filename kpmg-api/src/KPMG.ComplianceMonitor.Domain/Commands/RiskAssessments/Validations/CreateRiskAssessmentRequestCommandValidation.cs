using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;

public class CreateRiskAssessmentRequestCommandValidation : RiskAssessmentRequestValidation<CreateRiskAssessmentRequestCommand>
{
    public CreateRiskAssessmentRequestCommandValidation()
    {
        Validate();
    }
}
