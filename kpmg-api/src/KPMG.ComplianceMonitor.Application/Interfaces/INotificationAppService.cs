using KPMG.ComplianceMonitor.Application.Dtos.Notifications.Responses;

namespace KPMG.ComplianceMonitor.Application.Interfaces;

public interface INotificationAppService : IDisposable
{
    Task<IEnumerable<NotificationResponseDto>> GetAllNotReadAsync(Guid userId);

    Task UpdateSetToSentNotifications(IEnumerable<Guid> idsNotifications);
    Task UpdateSetToReadNotification(Guid idNotification);
}