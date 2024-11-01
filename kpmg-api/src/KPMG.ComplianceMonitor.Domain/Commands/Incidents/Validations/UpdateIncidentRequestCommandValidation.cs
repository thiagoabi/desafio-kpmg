using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public class UpdateIncidentRequestCommandValidation : IncidentRequestValidation<UpdateIncidentRequestCommand>
{
    public UpdateIncidentRequestCommandValidation()
    {
        ValidateId();
        ValidateResolution();
    }
}