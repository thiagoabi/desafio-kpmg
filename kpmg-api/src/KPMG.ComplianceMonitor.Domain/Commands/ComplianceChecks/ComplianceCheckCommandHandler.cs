using AutoMapper;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks;

public class ComplianceCheckCommandHandler : CommandHandler,
    IRequestHandler<CreateComplianceCheckRequestCommand, ValidationResult>,
    IRequestHandler<UpdateComplianceCheckRequestCommand, ValidationResult>,
    IRequestHandler<DeleteComplianceCheckRequestCommand, ValidationResult>
{
    private readonly IComplianceCheckRepository _ComplianceCheckRepository;

    public ComplianceCheckCommandHandler(IComplianceCheckRepository ComplianceCheckRepository, IMapper mapper)
        : base(mapper)
    {
        _ComplianceCheckRepository = ComplianceCheckRepository;
    }

    public async Task<ValidationResult> Handle(CreateComplianceCheckRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var entity = _mapper.Map<ComplianceCheck>(message);
        var domainEvent = _mapper.Map<ComplianceCheckCreatedEvent>(entity);

        entity.AddDomainEvent(domainEvent);

        await _ComplianceCheckRepository.AddAsync(entity);

        return await CommitAsync(_ComplianceCheckRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(UpdateComplianceCheckRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var ComplianceCheck = await _ComplianceCheckRepository.GetByIdAsync(message.Id!.Value);

        if (ComplianceCheck is null)
        {
            AddError("Não foi possível encontrar o registro de Auditoria de Conformidade especificado. Verifique se o ID está correto e se o registro existe.");

            return ValidationResult;
        }

        _mapper.Map(message, ComplianceCheck);

        var domainEvent = _mapper.Map<ComplianceCheckUpdatedEvent>(ComplianceCheck);

        ComplianceCheck.AddDomainEvent(domainEvent);

        _ComplianceCheckRepository.Update(ComplianceCheck);

        return await CommitAsync(_ComplianceCheckRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(DeleteComplianceCheckRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var ComplianceCheck = await _ComplianceCheckRepository.GetByIdAsync(message.Id!.Value);

        if (ComplianceCheck is null)
        {
            AddError("Não foi possível encontrar o registro de Auditoria de Conformidade especificado. Verifique se o ID está correto e se o registro existe.");

            return ValidationResult;
        }

        ComplianceCheck.AddDomainEvent(new ComplianceCheckLogDeletedEvent(message.Id!.Value));

        _ComplianceCheckRepository.Remove(ComplianceCheck);

        return await CommitAsync(_ComplianceCheckRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _ComplianceCheckRepository.Dispose();
    }
}