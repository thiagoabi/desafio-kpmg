using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings;

public class NotificationMap : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(n => n.Id)
            .ValueGeneratedOnAdd();

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.UserName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.NotificationDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(c => c.Message)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.IsRead)
            .IsRequired();

        builder.Property(c => c.IsSent)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasColumnType("datetime")
            .IsRequired(false);
    }
}

