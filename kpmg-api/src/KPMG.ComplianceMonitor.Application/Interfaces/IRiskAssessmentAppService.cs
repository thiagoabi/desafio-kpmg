using FluentValidation.Results;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Responses;

namespace KPMG.ComplianceMonitor.Application.Interfaces;

public interface IRiskAssessmentAppService : IDisposable
{
    Task<RiskAssessmentResponseDto> GetByIdAsync(Guid id);
    Task<IEnumerable<RiskAssessmentResponseDto>> GetAllAsync();

    Task<ValidationResult> CreateAsync(RiskAssessmentCreateRequestDto request);
    Task<ValidationResult> UpdateAsync(Guid id, RiskAssessmentUpdateRequestDto request);
    Task<ValidationResult> DeleteAsync(Guid id);
}