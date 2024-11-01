using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;

namespace KPMG.ComplianceMonitor.Domain.Core.Entities;

public abstract class Entity : IEntity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public virtual Guid Id { get; private set; }
    public DateTime? CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected Entity(Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
    }

    private List<Event>? _domainEvents;
    public IReadOnlyCollection<Event>? DomainEvents => _domainEvents?.AsReadOnly();

    public void SetCreatedAt()
    {
        CreatedAt = DateTime.Now;
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }

    public void AddDomainEvent(Event domainEvent)
    {
        _domainEvents ??= [];
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(Event domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    #region BaseBehaviours

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        
        if (compareTo is null) return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    #endregion
}