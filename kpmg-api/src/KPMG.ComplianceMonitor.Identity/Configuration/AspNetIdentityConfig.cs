using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.API;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Data.Context;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Configuration;

public static class AspNetIdentityConfig
{
    public static WebApplicationBuilder AddApiIdentityConfiguration(this WebApplicationBuilder builder)
    {
        builder.AddIdentityDbContext()
               .AddIdentityApiSupport()
               .AddJwtSupport()
               .AddAspNetUserSupport();

        return builder;
    }

    public static WebApplicationBuilder AddWebIdentityConfiguration(this WebApplicationBuilder builder)
    {
        builder.AddIdentityDbContext()
               .AddIdentityWebUISupport()
               .AddAspNetUserSupport();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ComplianceMonitorIdentityContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly("KPMG.ComplianceMonitor.Infra.CrossCutting.Identity")));

        return builder;
    }

    private static WebApplicationBuilder AddIdentityApiSupport(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<ComplianceMonitorIdentityContext>()
                        .AddSignInManager()
                        .AddRoleManager<RoleManager<IdentityRole>>()
                        .AddDefaultTokenProviders();

        return builder;
    }

    private static WebApplicationBuilder AddIdentityWebUISupport(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ComplianceMonitorIdentityContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

        return builder;
    }

    private static WebApplicationBuilder AddJwtSupport(this WebApplicationBuilder builder)
    {
        var appSettingsSection = builder.Configuration.GetSection("AppSettings");
        builder.Services.Configure<AppJwtSettings>(appSettingsSection);

        var appSettings = appSettingsSection.Get<AppJwtSettings>();
        var key = Encoding.ASCII.GetBytes(appSettings!.SecretKey);

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.Audience,
                    ValidIssuer = appSettings.Issuer
                };
            });

        return builder;
    }

    public static WebApplicationBuilder AddAspNetUserSupport(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IAspNetUser, AspNetUser>();

        return builder;
    }
}