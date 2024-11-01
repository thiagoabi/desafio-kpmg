using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Entities;

namespace KPMG.ComplianceMonitor.Domain.Interfaces;

public interface INotificationRepository : IRepository<Notification>
{
    Task<IEnumerable<Notification>> GetAllNotReadAsync(Guid userId);

    Task UpdateSetToSentNotifications(IEnumerable<Guid> idsNotifications);
    Task UpdateSetToReadNotification(Guid idNotification);
}