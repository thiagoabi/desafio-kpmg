using AutoMapper;
using KPMG.ComplianceMonitor.Application.Dtos.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;

namespace KPMG.ComplianceMonitor.Application.AutoMapper;

public class ComplianceCheckMappingProfile : Profile
{
    public ComplianceCheckMappingProfile()
    {
        CreateMap<ComplianceCheckCreateRequestDto, CreateComplianceCheckRequestCommand>()
            .ConstructUsing(c => new CreateComplianceCheckRequestCommand(c.ComplianceType, c.Description, c.CheckDate, c.Result, c.IssuesFound));

        CreateMap<CreateComplianceCheckRequestCommand, ComplianceCheck>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<ComplianceCheck, ComplianceCheckCreatedEvent>();

        CreateMap<ComplianceCheckUpdateRequestDto, UpdateComplianceCheckRequestCommand>()
            .ConstructUsing(c => new UpdateComplianceCheckRequestCommand(c.ComplianceType, c.Description, c.CheckDate, c.Result, c.IssuesFound))
            .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest, destMember, context) => (Guid)context.Items["Id"]));

        CreateMap<UpdateComplianceCheckRequestCommand, ComplianceCheck>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(default)));

        CreateMap<ComplianceCheck, ComplianceCheckUpdatedEvent>();

        CreateMap<ComplianceCheck, ComplianceCheckResponseDto>();
    }
}
