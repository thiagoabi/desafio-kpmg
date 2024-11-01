using AutoMapper;
using KPMG.ComplianceMonitor.Application.Interfaces;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Responses;

namespace KPMG.ComplianceMonitor.Application.Services;

public class RiskAssessmentAppService : IRiskAssessmentAppService
{
    private readonly IMapper _mapper;
    private readonly IRiskAssessmentRepository _riskAssessmentRepository;
    private readonly IMediatorHandler _mediator;

    public RiskAssessmentAppService(IMapper mapper,
                                     IRiskAssessmentRepository riskAssessmentRepository,
                                     IMediatorHandler mediator)
    {
        _mapper = mapper;
        _riskAssessmentRepository = riskAssessmentRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<RiskAssessmentResponseDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<RiskAssessmentResponseDto>>(await _riskAssessmentRepository.GetAllAsync());
    }

    public async Task<RiskAssessmentResponseDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<RiskAssessmentResponseDto>(await _riskAssessmentRepository.GetByIdAsync(id));
    }

    public async Task<ValidationResult> CreateAsync(RiskAssessmentCreateRequestDto request)
    {
        var createCommandFromDto = _mapper.Map<CreateRiskAssessmentRequestCommand>(request);

        return await _mediator.SendCommand(createCommandFromDto);
    }

    public async Task<ValidationResult> UpdateAsync(Guid id, RiskAssessmentUpdateRequestDto request)
    {
        var updateCommandFromDto = _mapper.Map<UpdateRiskAssessmentRequestCommand>(request, opt => opt.Items["Id"] = id);

        return await _mediator.SendCommand(updateCommandFromDto);
    }

    public async Task<ValidationResult> DeleteAsync(Guid id)
    {
        var deleteCommandFromId = _mapper.Map<DeleteRiskAssessmentRequestCommand>(id);

        return await _mediator.SendCommand(deleteCommandFromId);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
