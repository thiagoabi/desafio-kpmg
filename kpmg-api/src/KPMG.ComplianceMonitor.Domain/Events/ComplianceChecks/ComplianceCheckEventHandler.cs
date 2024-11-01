using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;

public class ComplianceCheckEventHandler :
    INotificationHandler<ComplianceCheckCreatedEvent>,
    INotificationHandler<ComplianceCheckUpdatedEvent>,
    INotificationHandler<ComplianceCheckLogDeletedEvent>
{
    public Task Handle(ComplianceCheckUpdatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(ComplianceCheckCreatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(ComplianceCheckLogDeletedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}