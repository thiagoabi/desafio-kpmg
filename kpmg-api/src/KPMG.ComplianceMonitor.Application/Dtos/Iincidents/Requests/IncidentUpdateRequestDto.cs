namespace KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;

public record IncidentUpdateRequestDto(bool? IsResolved, DateOnly? ResolutionDate, string? ResolutionDetails);