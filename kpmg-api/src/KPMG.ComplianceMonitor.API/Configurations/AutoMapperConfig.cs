using KPMG.ComplianceMonitor.Application.AutoMapper;
using System.Reflection;

namespace KPMG.ComplianceMonitor.Api.Configurations;

public static class AutoMapperConfig
{
    public static WebApplicationBuilder AddAutoMapperConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(IncidentMappingProfile)));

        return builder;
    }
}