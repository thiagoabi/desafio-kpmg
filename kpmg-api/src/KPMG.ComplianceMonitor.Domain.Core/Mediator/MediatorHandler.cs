﻿using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using MediatR;
using System.Runtime.CompilerServices;

namespace KPMG.ComplianceMonitor.Domain.Core.Mediator;

public class MediatorHandler : IMediatorHandler
{
    private readonly IMediator _mediator;

    public MediatorHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public virtual Task<ValidationResult> SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public virtual Task PublishEvent<T>(T @event) where T : Event
    {
        return _mediator.Publish(@event);
    }
}
