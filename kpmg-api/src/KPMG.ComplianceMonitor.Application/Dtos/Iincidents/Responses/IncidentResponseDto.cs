using KPMG.ComplianceMonitor.Domain.Enumerators;

public record IncidentResponseDto(Guid Id, Guid UserId, string UserName, EnumIncidentType IncidentType, EnumSeverityLevel SeverityLevel, 
    string Description, DateOnly IncidentDate, bool IsResolved, DateOnly? ResolutionDate, string? ResolutionDetails, DateTime CreatedAt, DateTime? UpdatedAt);
