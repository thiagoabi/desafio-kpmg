using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;

public record ComplianceCheckUpdateRequestDto(EnumComplianceType? ComplianceType,
        string? Description, DateOnly? CheckDate, EnumComplianceCheckResult? Result, string IssuesFound);