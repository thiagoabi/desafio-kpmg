using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;

public class RiskAssessmentLogDeletedEvent : Event
{
    public RiskAssessmentLogDeletedEvent(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}