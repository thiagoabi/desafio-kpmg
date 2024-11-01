namespace KPMG.ComplianceMonitor.Domain.Core.Interfaces;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}