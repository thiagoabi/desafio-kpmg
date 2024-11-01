using KPMG.ComplianceMonitor.Infra.CrossCutting.IoC;

namespace KPMG.ComplianceMonitor.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static WebApplicationBuilder AddDependencyInjectionConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        NativeInjectorBootStrapper.RegisterServices(builder);

        return builder;
    }
}