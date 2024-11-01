using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Events.Incidents;

public class IncidentLogDeletedEvent : Event
{
    public IncidentLogDeletedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}