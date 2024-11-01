using AutoMapper;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;

public class RiskAssessmentCommandHandler : CommandHandler,
    IRequestHandler<CreateRiskAssessmentRequestCommand, ValidationResult>,
    IRequestHandler<UpdateRiskAssessmentRequestCommand, ValidationResult>,
    IRequestHandler<DeleteRiskAssessmentRequestCommand, ValidationResult>
{
    private readonly IRiskAssessmentRepository _RiskAssessmentRepository;

    public RiskAssessmentCommandHandler(IRiskAssessmentRepository RiskAssessmentRepository, IMapper mapper)
        : base(mapper)
    {
        _RiskAssessmentRepository = RiskAssessmentRepository;
    }

    public async Task<ValidationResult> Handle(CreateRiskAssessmentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var entity = _mapper.Map<RiskAssessment>(message);
        var domainEvent = _mapper.Map<RiskAssessmentCreatedEvent>(entity);

        entity.AddDomainEvent(domainEvent);

        await _RiskAssessmentRepository.AddAsync(entity);

        return await CommitAsync(_RiskAssessmentRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(UpdateRiskAssessmentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var RiskAssessment = await _RiskAssessmentRepository.GetByIdAsync(message.Id!.Value);

        if (RiskAssessment is null)
        {
            AddError("Não foi possível localizar a Avaliação de Risco especificada. Verifique se o ID está correto e se o registro existe.");

            return ValidationResult;
        }

        _mapper.Map(message, RiskAssessment);

        var domainEvent = _mapper.Map<RiskAssessmentUpdatedEvent>(RiskAssessment);

        RiskAssessment.AddDomainEvent(domainEvent);

        _RiskAssessmentRepository.Update(RiskAssessment);

        return await CommitAsync(_RiskAssessmentRepository.UnitOfWork);
    }

    public async Task<ValidationResult> Handle(DeleteRiskAssessmentRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var RiskAssessment = await _RiskAssessmentRepository.GetByIdAsync(message.Id!.Value);

        if (RiskAssessment is null)
        {
            AddError("Não foi possível localizar a Avaliação de Risco especificada. Verifique se o ID está correto e se o registro existe.");

            return ValidationResult;
        }

        RiskAssessment.AddDomainEvent(new RiskAssessmentLogDeletedEvent(message.Id!.Value));

        _RiskAssessmentRepository.Remove(RiskAssessment);

        return await CommitAsync(_RiskAssessmentRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _RiskAssessmentRepository.Dispose();
    }
}