using FluentValidation.Results;
using KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Application.Interfaces;

public interface IComplianceCheckAppService : IDisposable
{
    Task<ComplianceCheckResponseDto> GetByIdAsync(Guid id);
    Task<IEnumerable<ComplianceCheckResponseDto>> GetAllAsync();

    Task<ValidationResult> CreateAsync(ComplianceCheckCreateRequestDto request);
    Task<ValidationResult> UpdateAsync(Guid id, ComplianceCheckUpdateRequestDto request);
    Task<ValidationResult> DeleteAsync(Guid id);
}