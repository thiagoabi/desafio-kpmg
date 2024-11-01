using AutoMapper;
using KPMG.ComplianceMonitor.Application.Interfaces;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;

namespace KPMG.ComplianceMonitor.Application.Services;

public class IncidentAppService : IIncidentAppService
{
    private readonly IMapper _mapper;
    private readonly IIncidentRepository _incidentRepository;
    private readonly IMediatorHandler _mediator;

    public IncidentAppService(IMapper mapper,
                              IIncidentRepository incidentRepository,
                              IMediatorHandler mediator)
    {
        _mapper = mapper;
        _incidentRepository = incidentRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<IncidentResponseDto>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<IncidentResponseDto>>(await _incidentRepository.GetAllAsync());
    }

    public async Task<IncidentResponseDto> GetByIdAsync(Guid id)
    {
        return _mapper.Map<IncidentResponseDto>(await _incidentRepository.GetByIdAsync(id));
    }

    public async Task<ValidationResult> CreateAsync(IncidentCreateRequestDto request)
    {
        var createCommandFromDto = _mapper.Map<CreateIncidentRequestCommand>(request);
       
        return await _mediator.SendCommand(createCommandFromDto);
    }

    public async Task<ValidationResult> UpdateAsync(Guid id, IncidentUpdateRequestDto request)
    {
        var updateCommandFromDto = _mapper.Map<UpdateIncidentRequestCommand>(request, opt => opt.Items["Id"] = id);

        return await _mediator.SendCommand(updateCommandFromDto);
    }

    public async Task<ValidationResult> DeleteAsync(Guid id)
    {
        var deleteCommandFromId = _mapper.Map<DeleteIncidentRequestCommand>(id);
       
        return await _mediator.SendCommand(deleteCommandFromId);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}