namespace KPMG.ComplianceMonitor.Application.Dtos.Notifications.Responses
{
    public record NotificationResponseDto(Guid Id, Guid UserId, string UserName, string Message, DateTime NotificationDate);
}