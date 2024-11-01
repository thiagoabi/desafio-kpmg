using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public class CreateIncidentRequestCommandValidation : IncidentRequestValidation<CreateIncidentRequestCommand>
{
    public CreateIncidentRequestCommandValidation()
    {
        ValidateUser();
        Validate();
    }
}
