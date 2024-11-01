using MediatR;

namespace KPMG.ComplianceMonitor.Domain.Core.Messaging;

public abstract class Event : Message, INotification
{
    protected Event()
    {
    }
}