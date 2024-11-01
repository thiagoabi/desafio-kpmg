using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Infra.Data.Mappings.Base;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.Data.Mappings;

public class RiskAssessmentMap : BaseMap<RiskAssessment>
{
    public override void Configure(EntityTypeBuilder<RiskAssessment> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.RiskCategory)
            .IsRequired();

        builder.Property(c => c.RiskDescription)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(c => c.ImpactLevel)
            .IsRequired();

        builder.Property(c => c.Likelihood)
            .IsRequired();

        builder.Property(c => c.MitigationPlan)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(c => c.AssessmentDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(c => c.Status)
            .IsRequired();
    }
}