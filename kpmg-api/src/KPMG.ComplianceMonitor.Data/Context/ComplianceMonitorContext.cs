using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.Data.Context;

public sealed class ComplianceMonitorContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public ComplianceMonitorContext(DbContextOptions<ComplianceMonitorContext> options, IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public DbSet<ComplianceCheck> ComplianceChecks { get; set; }
    public DbSet<ComplianceChecklist> ComplianceChecklists { get; set; }
    public DbSet<Incident> Incidents { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<RiskAssessment> RiskAssessments { get; set; }

    private readonly IList<string> NotificationCommands = [];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();

        modelBuilder.ApplyConfiguration(new ComplianceCheckMap());
        modelBuilder.ApplyConfiguration(new ComplianceChecklistMap());
        modelBuilder.ApplyConfiguration(new IncidentMap());
        modelBuilder.ApplyConfiguration(new NotificationMap());
        modelBuilder.ApplyConfiguration(new RiskAssessmentMap());

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> CommitAsync()
    {
        await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);

        var success = await SaveChangesAsync() > 0;

        if (success)
        {
            try
            {
                await Database.ExecuteSqlRawAsync(string.Join(';', NotificationCommands));
            }
            catch { }
        }
        return success;
    }

    internal void AddNotification(string message)
    {
        if (string.IsNullOrEmpty(message)) return;

        var sqlInsert = $@"INSERT INTO KPMGComplianceMonitor.dbo.Notifications
            (Id, UserId, UserName, Message, IsRead, IsSent, NotificationDate, CreatedAt)
            SELECT NEWID(), Id, UserName, '{message}', 0, 0, '{DateTime.Now}', '{DateTime.Now}' FROM AspNetUsers";

        NotificationCommands.Add(sqlInsert);
    }
}

public static class MediatorExtension
{
    public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
    {
        var domainEntities = ctx.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        domainEntities.ToList()
            .ForEach(entity => entity.Entity.ClearDomainEvents());

        var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                await mediator.PublishEvent(domainEvent);
            });

        await Task.WhenAll(tasks);
    }
}
