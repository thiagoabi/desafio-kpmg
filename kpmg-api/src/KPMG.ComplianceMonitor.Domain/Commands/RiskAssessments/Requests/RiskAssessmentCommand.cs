using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

public class RiskAssessmentCommand : Command
{
    public EnumRiskCategory? RiskCategory { get; protected set; }
    public string? RiskDescription { get; protected set; }
    public EnumImpactLevel? ImpactLevel { get; protected set; }
    public EnumLikelihood? Likelihood { get; protected set; }
    public string? MitigationPlan { get; protected set; }
    public DateOnly? AssessmentDate { get; protected set; }
    public EnumRiskAssessmentStatus? Status { get; protected set; }
}
