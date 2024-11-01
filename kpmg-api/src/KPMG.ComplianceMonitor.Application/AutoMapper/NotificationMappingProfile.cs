using AutoMapper;
using KPMG.ComplianceMonitor.Application.Dtos.Notifications.Responses;
using KPMG.ComplianceMonitor.Domain.Entities;

namespace KPMG.ComplianceMonitor.Application.AutoMapper;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<Notification, NotificationResponseDto>();


    }
}
