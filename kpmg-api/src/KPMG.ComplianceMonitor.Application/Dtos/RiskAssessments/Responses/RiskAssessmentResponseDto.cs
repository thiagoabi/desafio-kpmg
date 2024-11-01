using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Responses;

public record RiskAssessmentResponseDto(Guid Id, EnumRiskCategory RiskCategory, string RiskDescription, EnumImpactLevel ImpactLevel,
    EnumLikelihood Likelihood, string MitigationPlan, DateOnly AssessmentDate, EnumRiskAssessmentStatus Status);