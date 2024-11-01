using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;

public class ComplianceCheckCreatedEvent : Event
{
    public ComplianceCheckCreatedEvent(EnumComplianceType complianceType, string description, DateOnly checkDate,
        EnumComplianceCheckResult result, string issuesFound)
    {
        ComplianceType = complianceType;
        Description = description;
        CheckDate = checkDate;
        Result = result;
        IssuesFound = issuesFound;
    }

    public EnumComplianceType ComplianceType { get; private set; }
    public string Description { get; private set; }
    public DateOnly CheckDate { get; private set; }
    public EnumComplianceCheckResult Result { get; private set; }
    public string IssuesFound { get; private set; }
}
