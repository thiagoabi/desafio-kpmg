using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Mappings.Base;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings;

public class ComplianceChecklistMap : BaseMap<ComplianceChecklist>
{
    public override void Configure(EntityTypeBuilder<ComplianceChecklist> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.ComplianceCheckId)
            .IsRequired();

        builder.Property(c => c.ChecklistItem)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.IsCompliant)
            .IsRequired();

        builder.Property(c => c.Comments)
            .HasMaxLength(1000)
            .IsRequired(false);
    }
}
