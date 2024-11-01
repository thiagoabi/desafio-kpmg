using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Core.Mediator;

public interface IMediatorHandler
{
    Task PublishEvent<T>(T @event) where T : Event;
    Task<ValidationResult> SendCommand<T>(T command) where T : Command;
}