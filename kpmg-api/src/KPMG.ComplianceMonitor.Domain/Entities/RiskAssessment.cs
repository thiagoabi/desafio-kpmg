using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Entities;

public class RiskAssessment : Entity, IEntity, IAggregateRoot
{
    public RiskAssessment(EnumRiskCategory riskCategory, string riskDescription, EnumImpactLevel impactLevel,
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

    protected RiskAssessment() { }

    public EnumRiskCategory? RiskCategory { get; private set; }
    public string? RiskDescription { get; private set; }
    public EnumImpactLevel? ImpactLevel { get; private set; }
    public EnumLikelihood? Likelihood { get; private set; }
    public string? MitigationPlan { get; private set; }
    public DateOnly? AssessmentDate { get; private set; }
    public EnumRiskAssessmentStatus? Status { get; private set; }
}
