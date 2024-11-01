using ValidationResult = FluentValidation.Results.ValidationResult;

using KPMG.ComplianceMonitor.Infra.CrossCutting.Bus;
using KPMG.ComplianceMonitor.Infra.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using KPMG.ComplianceMonitor.Infra.Data.Repositories;
using KPMG.ComplianceMonitor.Application.Interfaces;
using KPMG.ComplianceMonitor.Application.Services;
using KPMG.ComplianceMonitor.Domain.Events.Incidents;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;
using KPMG.ComplianceMonitor.Domain.Events.ComplianceChecks;
using KPMG.ComplianceMonitor.Domain.Events.RiskAssessments;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks.Requests;
using KPMG.ComplianceMonitor.Domain.Commands.RiskAssessments.Requests;
using KPMG.ComplianceMonitor.Domain.Commands.Incidents;
using KPMG.ComplianceMonitor.Domain.Commands.ComplianceChecks;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMediatorHandler, InMemoryBus>();

        builder.Services.AddScoped<IComplianceCheckAppService, ComplianceCheckAppService>();
        builder.Services.AddScoped<IIncidentAppService, IncidentAppService>();
        builder.Services.AddScoped<INotificationAppService, NotificationAppService>();
        builder.Services.AddScoped<IRiskAssessmentAppService, RiskAssessmentAppService>();

        builder.Services.AddScoped<INotificationHandler<ComplianceCheckCreatedEvent>, ComplianceCheckEventHandler>();
        builder.Services.AddScoped<INotificationHandler<ComplianceCheckUpdatedEvent>, ComplianceCheckEventHandler>();
        builder.Services.AddScoped<INotificationHandler<ComplianceCheckLogDeletedEvent>, ComplianceCheckEventHandler>();


        builder.Services.AddScoped<INotificationHandler<IncidentCreatedEvent>, IncidentEventHandler>();
        builder.Services.AddScoped<INotificationHandler<IncidentUpdatedEvent>, IncidentEventHandler>();
        builder.Services.AddScoped<INotificationHandler<IncidentLogDeletedEvent>, IncidentEventHandler>();


        builder.Services.AddScoped<INotificationHandler< RiskAssessmentCreatedEvent>,  RiskAssessmentEventHandler>();
        builder.Services.AddScoped<INotificationHandler< RiskAssessmentUpdatedEvent>,  RiskAssessmentEventHandler>();
        builder.Services.AddScoped<INotificationHandler< RiskAssessmentLogDeletedEvent>,  RiskAssessmentEventHandler>();

        builder.Services.AddScoped<IRequestHandler<CreateComplianceCheckRequestCommand, ValidationResult>, ComplianceCheckCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateComplianceCheckRequestCommand, ValidationResult>, ComplianceCheckCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<DeleteComplianceCheckRequestCommand, ValidationResult>, ComplianceCheckCommandHandler>();


        builder.Services.AddScoped<IRequestHandler<CreateIncidentRequestCommand, ValidationResult>, IncidentCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateIncidentRequestCommand, ValidationResult>, IncidentCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<DeleteIncidentRequestCommand, ValidationResult>, IncidentCommandHandler>();

        builder.Services.AddScoped<IRequestHandler<UpdateReadNotificationRequestCommand, ValidationResult>, NotificationCommandHandler>();

        builder.Services.AddScoped<IRequestHandler<CreateRiskAssessmentRequestCommand, ValidationResult>, RiskAssessmentCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<UpdateRiskAssessmentRequestCommand, ValidationResult>, RiskAssessmentCommandHandler>();
        builder.Services.AddScoped<IRequestHandler<DeleteRiskAssessmentRequestCommand, ValidationResult>, RiskAssessmentCommandHandler>();

        builder.Services.AddScoped<IComplianceCheckRepository, ComplianceCheckRepository>();

        builder.Services.AddScoped<IComplianceChecklistRepository, ComplianceChecklistRepository>();

        builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();
        
        builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
        
        builder.Services.AddScoped<IRiskAssessmentRepository, RiskAssessmentRepository>();

        builder.Services.AddScoped<ComplianceMonitorContext>();
    }
}