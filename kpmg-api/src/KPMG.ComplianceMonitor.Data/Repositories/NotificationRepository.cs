using KPMG.ComplianceMonitor.Domain.Core.Interfaces;
using KPMG.ComplianceMonitor.Domain.Entities;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using KPMG.ComplianceMonitor.Infra.Data.Context;
using KPMG.ComplianceMonitor.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace KPMG.ComplianceMonitor.Infra.Data.Repositories;

public class NotificationRepository(ComplianceMonitorContext context)
    : Repository<Notification>(context, "Notificação"), IRepository<Notification>, INotificationRepository
{
    public async Task<IEnumerable<Notification>> GetAllNotReadAsync(Guid userId)
    {
        return await Db.Notifications
            .AsNoTracking()
            .Where(x => x.UserId == userId && !x.IsRead)
            .ToListAsync();
    }

    public async Task UpdateSetToSentNotifications(IEnumerable<Guid> idsNotifications)
    {
        await Db.Notifications
            .Where(x => idsNotifications.Contains(x.Id))
            .ExecuteUpdateAsync(setters => setters.SetProperty(y => y.IsSent, true));
    }

    public async Task UpdateSetToReadNotification(Guid idNotification)
    {
        var entity = await Db.Notifications.FindAsync(idNotification);

        if (entity is null) return;

        entity.SetUpdatedAt();

        entity.SetRead();

        Db.Update(entity);
    }
}
