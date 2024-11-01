using Microsoft.AspNetCore.Identity;
using KPMG.ComplianceMonitor.Api.Configurations;
using KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfiguration()
       .AddDatabaseConfiguration()
       .AddApiIdentityConfiguration()
       .AddAutoMapperConfiguration()
       .AddSwaggerConfiguration()
       .AddMediatRConfiguration()
       .AddDependencyInjectionConfiguration();

var app = builder.Build();

app.UseHttpsRedirection()
    .UseCors(c =>
    {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
    })
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.MapIdentityApi<IdentityUser>();

app.UseSwaggerSetup();

app.AddMigrationConfiguration();

app.Run();