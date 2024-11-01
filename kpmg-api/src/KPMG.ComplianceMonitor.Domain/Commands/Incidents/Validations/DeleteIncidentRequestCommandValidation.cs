using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;

public class DeleteIncidentRequestCommandValidation : IncidentRequestValidation<DeleteIncidentRequestCommand>
{
    public DeleteIncidentRequestCommandValidation()
    {
        ValidateId();
    }
}