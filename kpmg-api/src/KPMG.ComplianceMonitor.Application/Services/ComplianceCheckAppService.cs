using AutoMapper;
using KPMG.ComplianceMonitor.Application.Interfaces;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;

namespace KPMG.ComplianceMonitor.Application.Services;

public class ComplianceCheckAppService : IComplianceCheckAppService
{
    private readonly IMapper _mapper;
    private readonly IComplianceCheckRepository _complianceCheckRepository;
    private readonly IMediatorHandler _mediator;

    public ComplianceCheckAppService(IMapper mapper,
                                      IComplianceCheckRepository complianceCheckRepository,
                                      IMediatorHandler mediator)
    {
        _mapper = mapper;
        _complianceCheckRepository = complianceCheckRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ComplianceCheckResponseDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<ComplianceCheckResponseDto>>(await _complianceCheckRepository.GetAllAsync());
    }

    public async Task<ComplianceCheckResponseDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<ComplianceCheckResponseDto>(await _complianceCheckRepository.GetByIdAsync(id));
    }

    public async Task<ValidationResult> CreateAsync(ComplianceCheckCreateRequestDto request)
    {
        var createCommandFromDto = _mapper.Map<CreateComplianceCheckRequestCommand>(request);

        return await _mediator.SendCommand(createCommandFromDto);
    }

    public async Task<ValidationResult> UpdateAsync(Guid id, ComplianceCheckUpdateRequestDto request)
    {
        var updateCommandFromDto = _mapper.Map<UpdateComplianceCheckRequestCommand>(request, opt => opt.Items["Id"] = id);

        return await _mediator.SendCommand(updateCommandFromDto);
    }

    public async Task<ValidationResult> DeleteAsync(Guid id)
    {
        var deleteCommandFromId = _mapper.Map<DeleteComplianceCheckRequestCommand>(id);

        return await _mediator.SendCommand(deleteCommandFromId);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}