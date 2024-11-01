using FluentValidation.Results;
using KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;

namespace KPMG.ComplianceMonitor.Application.Interfaces;

public interface IIncidentAppService : IDisposable
{
    Task<IncidentResponseDto> GetByIdAsync(Guid id);
    Task<IEnumerable<IncidentResponseDto>> GetAllAsync();

    Task<ValidationResult> CreateAsync(IncidentCreateRequestDto request);
    Task<ValidationResult> UpdateAsync(Guid id, IncidentUpdateRequestDto request);
    Task<ValidationResult> DeleteAsync(Guid id);
}