using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

public class DeleteRiskAssessmentRequestCommand : RiskAssessmentCommand
{
    public DeleteRiskAssessmentRequestCommand(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new DeleteRiskAssessmentRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
