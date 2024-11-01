using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Validations;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

public class UpdateRiskAssessmentRequestCommand : RiskAssessmentCommand
{
    public UpdateRiskAssessmentRequestCommand(EnumRiskCategory? riskCategory, string? riskDescription, EnumImpactLevel? impactLevel,
        EnumLikelihood? likelihood, string? mitigationPlan, DateOnly? assessmentDate, EnumRiskAssessmentStatus? status)
    {
        RiskCategory = riskCategory;
        RiskDescription = riskDescription;
        ImpactLevel = impactLevel;
        Likelihood = likelihood;
        MitigationPlan = mitigationPlan;
        AssessmentDate = assessmentDate;
        Status = status;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateRiskAssessmentRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
