using KPMG.ComplianceMonitor.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Api.Configurations;

public static partial class DatabaseConfig
{
    public static WebApplicationBuilder AddDatabaseConfiguration(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ComplianceMonitorContext>(options =>
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information)); 

        return builder;
    }
}