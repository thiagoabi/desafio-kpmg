using AutoMapper;
using KPMG.ComplianceMonitor.Application.Dtos.Users.Responses;
using Microsoft.AspNetCore.Identity;

namespace KPMG.ComplianceMonitor.Application.AutoMapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<IdentityUser, UserResponseDto>();
    }
}
