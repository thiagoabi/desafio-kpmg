using KPMG.ComplianceMonitor.Domain.Core.Entities;

namespace KPMG.ComplianceMonitor.Domain.Core.Interfaces;

public interface IRepository<TEntity> : IDisposable 
    where TEntity : Entity, IEntity, IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }

    Task<TEntity?> GetByIdAsync(Guid id);

    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetAllWithNoTrackingAsync();


    Task<bool> ExistsAsync(Guid id);

    Task AddAsync(TEntity customer);
    void Update(TEntity customer);
    void Remove(TEntity customer);
}