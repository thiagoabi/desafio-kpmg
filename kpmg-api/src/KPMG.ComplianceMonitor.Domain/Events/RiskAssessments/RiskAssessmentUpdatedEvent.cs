using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;

public class RiskAssessmentUpdatedEvent : Event
{
    public RiskAssessmentUpdatedEvent(Guid id, EnumRiskCategory riskCategory, string riskDescription, EnumImpactLevel impactLevel,
        EnumLikelihood likelihood, string mitigationPlan, DateOnly assessmentDate, EnumRiskAssessmentStatus status)
    {
        Id = id;
        RiskCategory = riskCategory;
        RiskDescription = riskDescription;
        ImpactLevel = impactLevel;
        Likelihood = likelihood;
        MitigationPlan = mitigationPlan;
        AssessmentDate = assessmentDate;
        Status = status;
    }

    public Guid Id { get; set; }
    public EnumRiskCategory RiskCategory { get; private set; }
    public string RiskDescription { get; private set; }
    public EnumImpactLevel ImpactLevel { get; private set; }
    public EnumLikelihood Likelihood { get; private set; }
    public string MitigationPlan { get; private set; }
    public DateOnly AssessmentDate { get; private set; }
    public EnumRiskAssessmentStatus Status { get; private set; }
}