using AutoMapper;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.Incidents;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents;

public class IncidentCommandHandler : CommandHandler,
    IRequestHandler<CreateIncidentRequestCommand, ValidationResult>,
    IRequestHandler<UpdateIncidentRequestCommand, ValidationResult>,
    IRequestHandler<DeleteIncidentRequestCommand, ValidationResult>
{
    private readonly IIncidentRepository _incidentRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public IncidentCommandHandler(IIncidentRepository incidentRepository, UserManager<IdentityUser> userManager, IMapper mapper)
        : base(mapper)
    {
        _incidentRepository = incidentRepository;
        _userManager = userManager;
    }

    public async Task<ValidationResult> Handle(CreateIncidentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var entity = _mapper.Map<Incident>(message);
        var user = await _userManager.FindByIdAsync(message.UserId.ToString()!);

        if (user is null)
        {
            AddError("Usuário informado não existe.");
            return ValidationResult;
        }

        entity.UserName = user.UserName;

        var domainEvent = _mapper.Map<IncidentCreatedEvent>(entity);

        entity.AddDomainEvent(domainEvent);

        await _incidentRepository.AddAsync(entity);

        return await CommitAsync(_incidentRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(UpdateIncidentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var incident = await _incidentRepository.GetByIdAsync(message.Id!.Value);

        if (incident is null)
        {
            AddError("O Incidente não existe.");
            return ValidationResult;
        }

        _mapper.Map(message, incident);

        var domainEvent = _mapper.Map<IncidentUpdatedEvent>(incident);

        incident.AddDomainEvent(domainEvent);

        _incidentRepository.Update(incident);

        return await CommitAsync(_incidentRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(DeleteIncidentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var incident = await _incidentRepository.GetByIdAsync(message.Id!.Value);

        if (incident is null)
        {
            AddError("O Incidente não existe.");
            return ValidationResult;
        }

        incident.AddDomainEvent(new IncidentLogDeletedEvent(message.Id!.Value));

        _incidentRepository.Remove(incident);

        return await CommitAsync(_incidentRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _incidentRepository.Dispose();
    }
}