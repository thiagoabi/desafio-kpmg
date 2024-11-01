using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Mappings.Base;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings;

public class IncidentMap : BaseMap<Incident>
{
    public override void Configure(EntityTypeBuilder<Incident> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.UserId)
            .IsRequired();

        builder.Property(c => c.UserName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(c => c.IncidentType)
            .IsRequired();

        builder.Property(c => c.SeverityLevel)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(c => c.IncidentDate)
            .IsRequired();

        builder.Property(c => c.IsResolved)
            .IsRequired();

        builder.Property(c => c.ResolutionDate)
            .IsRequired(false);

        builder.Property(c => c.ResolutionDetails)
            .HasMaxLength(2000)
            .IsRequired(false);
    }
}
