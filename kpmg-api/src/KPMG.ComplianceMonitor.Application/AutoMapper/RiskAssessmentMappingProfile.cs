using AutoMapper;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Application.Dtos.RiskAssessments.Responses;
using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;

namespace KPMG.ComplianceMonitor.Application.AutoMapper;

public class RiskAssessmentMappingProfile : Profile
{
    public RiskAssessmentMappingProfile()
    {
        CreateMap<RiskAssessmentCreateRequestDto, CreateRiskAssessmentRequestCommand>()
            .ConstructUsing(c => new CreateRiskAssessmentRequestCommand(c.RiskCategory, c.RiskDescription, c.ImpactLevel,c.Likelihood, c.MitigationPlan, c.AssessmentDate, c.Status));

        CreateMap<CreateRiskAssessmentRequestCommand, RiskAssessment>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));

        CreateMap<RiskAssessment, RiskAssessmentCreatedEvent>();

        CreateMap<RiskAssessmentUpdateRequestDto, UpdateRiskAssessmentRequestCommand>()
            .ConstructUsing(c => new UpdateRiskAssessmentRequestCommand(c.RiskCategory, c.RiskDescription, c.ImpactLevel, c.Likelihood, c.MitigationPlan, c.AssessmentDate, c.Status))
            .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest, destMember, context) => (Guid)context.Items["Id"]));


        CreateMap<UpdateRiskAssessmentRequestCommand, RiskAssessment>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(default)));

        CreateMap<RiskAssessment, RiskAssessmentUpdatedEvent>();

        CreateMap<RiskAssessment, RiskAssessmentResponseDto>();

    }
}
