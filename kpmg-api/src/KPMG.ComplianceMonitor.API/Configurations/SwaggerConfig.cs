using Microsoft.OpenApi.Models;

namespace KPMG.ComplianceMonitor.Api.Configurations;

public static class SwaggerConfig
{
    public static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Compliance Monitor Project",
                Description = "Compliance Monitor API Swagger surface"
            });

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Input the JWT like: Bearer {your token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });

            s.DocInclusionPredicate((docName, apiDesc) =>
            {
                var relativePath = apiDesc.RelativePath;

                var identityEndpoints = new[]
                {
                    "register",
                    "manage",
                    "refresh",
                    "login",
                    "confirmEmail",
                    "resendConfirmationEmail",
                    "forgotPassword",
                    "resetPassword"                        
                };

                foreach (var endpoint in identityEndpoints)
                {
                    if (relativePath.Contains(endpoint, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }

                return true;
            });

        });

        return builder;
    }

    public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}