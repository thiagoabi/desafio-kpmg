using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Data.Context;

public class ComplianceMonitorIdentityContext : IdentityDbContext
{
    public ComplianceMonitorIdentityContext(DbContextOptions<ComplianceMonitorIdentityContext> options) : base(options)
    { }
}