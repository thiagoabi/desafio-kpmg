using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;

public class RiskAssessmentCreatedEvent : Event
{
    public RiskAssessmentCreatedEvent(EnumRiskCategory riskCategory, string riskDescription, EnumImpactLevel impactLevel,
        EnumLikelihood likelihood, string mitigationPlan, DateOnly assessmentDate, EnumRiskAssessmentStatus status)
    {
        RiskCategory = riskCategory;
        RiskDescription = riskDescription;
        ImpactLevel = impactLevel;
        Likelihood = likelihood;
        MitigationPlan = mitigationPlan;
        AssessmentDate = assessmentDate;
        Status = status;
    }

    public EnumRiskCategory RiskCategory { get; private set; }
    public string RiskDescription { get; private set; }
    public EnumImpactLevel ImpactLevel { get; private set; }
    public EnumLikelihood Likelihood { get; private set; }
    public string MitigationPlan { get; private set; }
    public DateOnly AssessmentDate { get; private set; }
    public EnumRiskAssessmentStatus Status { get; private set; }
}