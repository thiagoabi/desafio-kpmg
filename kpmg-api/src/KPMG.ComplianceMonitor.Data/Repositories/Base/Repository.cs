using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using KPMG.ComplianceMonitor.Domain.Core.Entities;

namespace KPMG.ComplianceMonitor.Infra.Data.Repositories.Base;

public class Repository<TEntity> : IDisposable, IRepository<TEntity>
    where TEntity : Entity, IEntity, IAggregateRoot
{
    protected readonly ComplianceMonitorContext Db;
    protected readonly DbSet<TEntity> DbSet;

    private readonly string NotificationDescription;

    public IUnitOfWork UnitOfWork => Db;

    public Repository(ComplianceMonitorContext context, string notificationDescription)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();

        NotificationDescription = notificationDescription;
    }

    public Repository(ComplianceMonitorContext context)
    {
        Db = context;
        DbSet = Db.Set<TEntity>();

        NotificationDescription = string.Empty;
    }

    public async virtual Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async virtual Task<IEnumerable<TEntity>> GetAllWithNoTrackingAsync()
    {
        return await DbSet
            .AsNoTracking()
            .ToListAsync();
    }

    public async virtual Task<bool> ExistsAsync(Guid id)
    {
        return  await DbSet.FindAsync(id) is not null;
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        entity.SetCreatedAt();
        await DbSet.AddAsync(entity);
        Db.AddNotification($"Um novo registro de {NotificationDescription} foi criado no sistema.");
    }

    public virtual void Update(TEntity entity)
    {
        entity.SetUpdatedAt();
        DbSet.Update(entity);
        Db.AddNotification($"Um registro de {NotificationDescription} foi atualizado no sistema.");
    }

    public virtual void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
        Db.AddNotification($"Um registro de {NotificationDescription} foi removido do sistema");
    }

    public virtual void Dispose() => Db.Dispose();
}
