using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

public class UpdateReadNotificationRequestCommand : IncidentCommand
{
    public UpdateReadNotificationRequestCommand(Guid id)
    {
        Id = id;
    }

    public override bool IsValid()
    {
        ValidationResult = new UpdateReadNotificationRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
