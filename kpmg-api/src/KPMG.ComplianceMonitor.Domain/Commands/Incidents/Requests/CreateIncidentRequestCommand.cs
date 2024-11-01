using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Validations;
using KPMG.ComplianceMonitor.Domain.Enumerators;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

public class CreateIncidentRequestCommand : IncidentCommand
{
    public CreateIncidentRequestCommand(Guid? userId, string? userName, EnumIncidentType? incidentType,
        EnumSeverityLevel? severityLevel, string? description,
        DateOnly? incidentDate)
    {
        UserId = userId;
        UserName = userName;
        IncidentType = incidentType;
        SeverityLevel = severityLevel;
        Description = description;
        IncidentDate = incidentDate;
        IsResolved = false;
    }

    public override bool IsValid()
    {
        ValidationResult = new CreateIncidentRequestCommandValidation().Validate(this);

        return base.IsValid();
    }
}
