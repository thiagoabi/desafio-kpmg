using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

public class DeleteIncidentRequestCommand : IncidentCommand
{
    public DeleteIncidentRequestCommand(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new DeleteIncidentRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
