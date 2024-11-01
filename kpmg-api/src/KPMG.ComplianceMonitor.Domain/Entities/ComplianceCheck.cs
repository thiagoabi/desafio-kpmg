using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Entities;

public class ComplianceCheck : Entity, IEntity, IAggregateRoot
{
    public ComplianceCheck(Guid id, EnumComplianceType complianceType,
        string description, DateOnly checkDate,
        EnumComplianceCheckResult result, string issuesFound)
        : base(id)
    {
        ComplianceType = complianceType;
        Description = description;
        CheckDate = checkDate;
        Result = result;
        IssuesFound = issuesFound;
    }

    protected ComplianceCheck() { }

    public EnumComplianceType? ComplianceType { get; private set; }
    public string? Description { get; private set; }
    public DateOnly?CheckDate { get; private set; }
    public EnumComplianceCheckResult? Result { get; private set; }
    public string? IssuesFound { get; private set; }

    public virtual IEnumerable<ComplianceChecklist>? ComplianceChecklists { get; private set; }
}
