using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public class UpdateReadNotificationRequestCommandValidation : NotificationRequestValidation<UpdateReadNotificationRequestCommand>
{
    public UpdateReadNotificationRequestCommandValidation()
    {
        ValidateId();
    }
}