using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

public class ComplianceCheckCommand : Command
{
    public EnumComplianceType? ComplianceType { get; protected set; }
    public string? Description { get; protected set; }
    public DateOnly? CheckDate { get; protected set; }
    public EnumComplianceCheckResult? Result { get; protected set; }
    public string? IssuesFound { get; protected set; }
}
