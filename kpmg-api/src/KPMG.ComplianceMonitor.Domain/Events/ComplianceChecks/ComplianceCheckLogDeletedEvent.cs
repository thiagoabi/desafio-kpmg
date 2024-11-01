using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;

public class ComplianceCheckLogDeletedEvent : Event
{
    public ComplianceCheckLogDeletedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}