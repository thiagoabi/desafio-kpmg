using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Events.Incidents;

public class IncidentEventHandler :
    INotificationHandler<IncidentCreatedEvent>,
    INotificationHandler<IncidentUpdatedEvent>,
    INotificationHandler<IncidentLogDeletedEvent>
{
    public Task Handle(IncidentUpdatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(IncidentCreatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(IncidentLogDeletedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}