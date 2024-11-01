using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Validations;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;

public class UpdateComplianceCheckRequestCommand : ComplianceCheckCommand
{
    public UpdateComplianceCheckRequestCommand(EnumComplianceType? complianceType,
        string? description, DateOnly? checkDate,
        EnumComplianceCheckResult? result, string? issuesFound)
    {
        ComplianceType = complianceType;
        Description = description;
        CheckDate = checkDate;
        Result = result;
        IssuesFound = issuesFound;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateComplianceCheckRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
