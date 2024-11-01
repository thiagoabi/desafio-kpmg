using KPMG.ComplianceMonitor.Domain.Enumerators;

public record ComplianceCheckResponseDto(Guid Id, EnumComplianceType ComplianceType, string Description,
    DateOnly CheckDate, EnumComplianceCheckResult Result, string IssuesFound);
