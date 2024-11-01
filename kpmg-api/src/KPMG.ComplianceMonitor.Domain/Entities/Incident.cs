using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Entities;

public class Incident : Entity, IEntity, IAggregateRoot
{
    public Incident(Guid id, Guid userId, string userName, EnumIncidentType incidentType,
        EnumSeverityLevel severityLevel, string description,
        DateOnly incidentDate, bool resolved = false,
        DateOnly? resolutionDate = null, string? resolutionDetails = null)
        : base(id)
    {
        UserId = userId;
        UserName = userName;
        IncidentType = incidentType;
        SeverityLevel = severityLevel;
        Description = description;
        IncidentDate = incidentDate;
        IsResolved = resolved;
        ResolutionDate = resolutionDate;
        ResolutionDetails = resolutionDetails;
    }

    protected Incident() { }

    public Guid? UserId { get; private set; }
    public string? UserName { get; set; }
    public EnumIncidentType? IncidentType { get; private set; }
    public EnumSeverityLevel? SeverityLevel { get; private set; }
    public string? Description { get; private set; }
    public DateOnly? IncidentDate { get; private set; }
    public bool IsResolved { get; private set; }
    public DateOnly? ResolutionDate { get; private set; }
    public string? ResolutionDetails { get; private set; }
}