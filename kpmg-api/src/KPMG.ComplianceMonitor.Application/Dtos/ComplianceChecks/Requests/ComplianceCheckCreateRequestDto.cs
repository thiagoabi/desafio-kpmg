using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;

public record ComplianceCheckCreateRequestDto(EnumComplianceType? ComplianceType, string? Description, 
    DateOnly? CheckDate, EnumComplianceCheckResult? Result, string? IssuesFound);