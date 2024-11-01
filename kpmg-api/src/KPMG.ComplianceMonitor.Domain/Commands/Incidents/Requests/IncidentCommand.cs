using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests
{
    public abstract class IncidentCommand : Command
    {
        public Guid? UserId { get; protected set; }
        public string? UserName { get; protected set; }
        public EnumIncidentType? IncidentType { get; protected set; }
        public EnumSeverityLevel? SeverityLevel { get; protected set; }
        public string? Description { get; protected set; }
        public DateOnly? IncidentDate { get; protected set; }
        public bool? IsResolved { get; protected set; }
        public DateOnly? ResolutionDate { get; protected set; }
        public string? ResolutionDetails { get; protected set; }
    }
}