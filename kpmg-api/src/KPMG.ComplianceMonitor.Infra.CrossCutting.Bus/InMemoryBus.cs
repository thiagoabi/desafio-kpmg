using FluentValidation.Results;
using MediatR;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Bus;

public sealed class InMemoryBus(IMediator mediator) : IMediatorHandler
{
    private readonly IMediator _mediator = mediator;

    public async Task PublishEvent<T>(T @event) where T : Event
    {
        await _mediator.Publish(@event);
    }

    public async Task<ValidationResult> SendCommand<T>(T command) where T : Command
    {
        return await _mediator.Send(command);
    }
}