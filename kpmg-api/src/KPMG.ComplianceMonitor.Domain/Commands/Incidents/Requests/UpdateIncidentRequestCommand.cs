using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

public class UpdateIncidentRequestCommand : IncidentCommand
{
    public UpdateIncidentRequestCommand(bool? isResolved,
        DateOnly? resolutionDate, string? resolutionDetails)
    {
        IsResolved = isResolved;
        ResolutionDate = resolutionDate;
        ResolutionDetails = resolutionDetails;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateIncidentRequestCommandValidation().Validate(this);
        
        return base.IsValid();
    }
}
