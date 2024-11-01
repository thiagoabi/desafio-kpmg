using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Events.Incidents;

public class IncidentCreatedEvent : Event
{
    public IncidentCreatedEvent(Guid userId, string userName, EnumIncidentType incidentType,
        EnumSeverityLevel severityLevel, string description,
        DateOnly incidentDate, bool isResolved,
        DateOnly resolutionDate, string resolutionDetails)
    {
        UserId = userId;
        UserName = userName;
        IncidentType = incidentType;
        SeverityLevel = severityLevel;
        Description = description;
        IncidentDate = incidentDate;
        IsResolved = isResolved;
        ResolutionDate = resolutionDate;
        ResolutionDetails = resolutionDetails;
    }

    public Guid UserId { get; private set; }
    public string? UserName { get; private set; }
    public EnumIncidentType IncidentType { get; private set; }
    public EnumSeverityLevel SeverityLevel { get; private set; }
    public string Description { get; private set; }
    public DateOnly IncidentDate { get; private set; }
    public bool IsResolved { get; private set; }
    public DateOnly? ResolutionDate { get; private set; }
    public string? ResolutionDetails { get; private set; }
}