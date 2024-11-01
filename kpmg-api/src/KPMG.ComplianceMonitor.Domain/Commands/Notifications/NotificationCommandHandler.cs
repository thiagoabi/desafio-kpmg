using AutoMapper;
using FluentValidation.Results;
using KPMG.ComplianceMonitor.Domain.Core.Messaging;
using KPMG.ComplianceMonitor.Domain.Events.Incidents;
using KPMG.ComplianceMonitor.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace KPMG.ComplianceMonitor.Domain.Commands.Incidents.Requests;

public class NotificationCommandHandler : CommandHandler, IRequestHandler<UpdateReadNotificationRequestCommand, ValidationResult>
{
    private readonly INotificationRepository _notificationRepository;
    private readonly UserManager<IdentityUser> _userManager;

    public NotificationCommandHandler(INotificationRepository notificationRepository, UserManager<IdentityUser> userManager, IMapper mapper)
        : base(mapper)
    {
        _notificationRepository = notificationRepository;
        _userManager = userManager;
    }

    public async Task<ValidationResult> Handle(UpdateReadNotificationRequestCommand message, CancellationToken cancellationToken)
    {
        if (!message.IsValid()) return message.ValidationResult;

        var notification = await _notificationRepository.GetByIdAsync(message.Id!.Value);

        if (notification is null) return new ValidationResult();

        notification.AddDomainEvent(new IncidentLogDeletedEvent(message.Id!.Value));

        _notificationRepository.Remove(notification);

        return await CommitAsync(_notificationRepository.UnitOfWork);
    }

    public void Dispose()
    {
        _notificationRepository.Dispose();
    }
}