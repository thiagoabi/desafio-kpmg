using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Core.Entities;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings.Base;

public abstract class BaseMap<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity, IEntity, IAggregateRoot
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}
