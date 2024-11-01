using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;

public class RiskAssessmentEventHandler :
    INotificationHandler<RiskAssessmentCreatedEvent>,
    INotificationHandler<RiskAssessmentUpdatedEvent>,
    INotificationHandler<RiskAssessmentLogDeletedEvent>
{
    public Task Handle(RiskAssessmentUpdatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(RiskAssessmentCreatedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task Handle(RiskAssessmentLogDeletedEvent message, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}