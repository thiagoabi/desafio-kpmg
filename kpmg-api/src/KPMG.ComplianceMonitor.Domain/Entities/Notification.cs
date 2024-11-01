using KPMG.ComplianceMonitor.Domain.Core.Entities;
using KPMG.ComplianceMonitor.Domain.Core.Interfaces;

namespace KPMG.ComplianceMonitor.Domain.Entities;

public class Notification : Entity, IEntity, IAggregateRoot
{

    public Guid UserId { get; private set; }
    public string? UserName { get; private set; }
    public string? Message { get; private set; }
    public DateTime? NotificationDate { get; private set; }
    public bool IsRead { get; private set; }
    public bool IsSent { get; private set; }

    public Notification(Guid id, Guid userId, string userName,
        string message, DateTime notificationDate,
        bool isRead, bool isSent)
        : base(id)
    {
        UserId = userId;
        UserName = userName;
        Message = message;
        NotificationDate = notificationDate;
        IsRead = isRead;
        IsSent = isSent;
        
    }

    protected Notification() { }

    public void SetRead()
    {
        IsRead = true;
    }
}
