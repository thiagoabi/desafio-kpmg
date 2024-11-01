using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings;

public class ComplianceCheckMap : BaseMap<ComplianceCheck>
{
    public override void Configure(EntityTypeBuilder<ComplianceCheck> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.ComplianceType)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.CheckDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.Result)
            .IsRequired();

        builder.Property(c => c.IssuesFound)
            .HasMaxLength(2000)
            .IsRequired();

        builder
            .HasMany(x => x.ComplianceChecklists)
            .WithOne(x => x.ComplianceCheck)
            .HasForeignKey(x => x.ComplianceCheckId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
