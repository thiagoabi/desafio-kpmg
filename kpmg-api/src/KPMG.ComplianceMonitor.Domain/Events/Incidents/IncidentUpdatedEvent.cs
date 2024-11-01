using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Events.Incidents;

public class IncidentUpdatedEvent : Event
{
    public IncidentUpdatedEvent(Guid id, bool isResolved,
        DateOnly resolutionDate, string resolutionDetails)
    {
        Id = id;
        IsResolved = isResolved;
        ResolutionDate = resolutionDate;
        ResolutionDetails = resolutionDetails;
    }

    public Guid Id { get; set; }
    public bool IsResolved { get; private set; }
    public DateOnly? ResolutionDate { get; private set; }
    public string? ResolutionDetails { get; private set; }
}