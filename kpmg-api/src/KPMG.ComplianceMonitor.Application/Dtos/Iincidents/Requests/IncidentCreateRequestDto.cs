using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;

public record IncidentCreateRequestDto(Guid? UserId, string? UserName, EnumIncidentType? IncidentType, EnumSeverityLevel? SeverityLevel, string? Description, 
    DateOnly? IncidentDate);
