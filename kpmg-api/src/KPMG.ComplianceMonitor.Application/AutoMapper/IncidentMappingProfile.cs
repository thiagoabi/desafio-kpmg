using AutoMapper;
using KPMG.ComplianceMonitor.Application.Dtos.Iincidents.Requests;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.Incidents;

namespace KPMG.ComplianceMonitor.Application.AutoMapper;

public class IncidentMappingProfile : Profile
{
    public IncidentMappingProfile()
    {
        CreateMap<IncidentCreateRequestDto, CreateIncidentRequestCommand>()
            .ConstructUsing(c => new CreateIncidentRequestCommand(c.UserId, c.UserName, c.IncidentType, c.SeverityLevel, c.Description, c.IncidentDate));

        CreateMap<CreateIncidentRequestCommand, Incident>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName.ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<Incident, IncidentCreatedEvent>();

        CreateMap<IncidentUpdateRequestDto, UpdateIncidentRequestCommand>()
            .ConstructUsing(c => new UpdateIncidentRequestCommand(c.IsResolved, c.ResolutionDate, c.ResolutionDetails))
            .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest, destMember, context) => (Guid)context.Items["Id"]));

        CreateMap<UpdateIncidentRequestCommand, Incident>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(default)));

        CreateMap<Incident, IncidentUpdatedEvent>();

        CreateMap<Incident, IncidentResponseDto>();
    }
}
