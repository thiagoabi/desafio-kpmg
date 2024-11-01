using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Data.Context;
using KPMG.ComplianceMonitor.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Api.Configurations;

public static partial class DatabaseConfig
{
    public static WebApplication AddMigrationConfiguration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ComplianceMonitorContext>();
        dbContext.Database.Migrate();

        var identityContext = scope.ServiceProvider.GetRequiredService<ComplianceMonitorIdentityContext>();
        identityContext.Database.Migrate();

        return app;
    }
}
