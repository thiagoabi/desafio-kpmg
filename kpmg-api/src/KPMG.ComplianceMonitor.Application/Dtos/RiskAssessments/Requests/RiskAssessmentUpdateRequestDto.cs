using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Requests;

public record RiskAssessmentUpdateRequestDto(EnumRiskCategory? RiskCategory, string? RiskDescription, EnumImpactLevel? ImpactLevel,
        EnumLikelihood? Likelihood, string? MitigationPlan, DateOnly? AssessmentDate, EnumRiskAssessmentStatus? Status);