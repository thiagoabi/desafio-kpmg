using AutoMapper;
using KPMG.ComplianceMonitor.Application.Interfaces;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using KPMG.ComplianceMonitor.Domain.Core.Mediator;
using KPMG.ComplianceMonitor.Application.Dtos.Notifications.Responses;

namespace KPMG.ComplianceMonitor.Application.Services;

public class NotificationAppService : INotificationAppService
{
    private readonly IMapper _mapper;
    private readonly INotificationRepository _notificationRepository;
    private readonly IMediatorHandler _mediator;

    public NotificationAppService(IMapper mapper,
                                  INotificationRepository notificationRepository,
                                  IMediatorHandler mediator)
    {
        _mapper = mapper;
        _notificationRepository = notificationRepository;
        _mediator = mediator;
    }

    public async Task<IEnumerable<NotificationResponseDto>> GetAllNotReadAsync(Guid userId)
    {
        return _mapper.Map<IEnumerable<NotificationResponseDto>>(await _notificationRepository.GetAllNotReadAsync(userId));
    }

    public async Task UpdateSetToSentNotifications(IEnumerable<Guid> idsNotifications)
    {
        await _notificationRepository.UpdateSetToSentNotifications(idsNotifications);
    }

    public async Task UpdateSetToReadNotification(Guid idNotification)
    {
        await _notificationRepository.UpdateSetToReadNotification(idNotification);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
