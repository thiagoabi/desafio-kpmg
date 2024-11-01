using KPMG.ComplianceMonitor.Api.Controllers.Base;
using KPMG.ComplianceMonitor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace KPMG.ComplianceMonitor.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class NotificationsController : CustomControllerBase
{
    private readonly INotificationAppService _notificationService;

    public NotificationsController(INotificationAppService notificationService)
    { 
     _notificationService = notificationService;
    }

    [HttpGet("stream/{userId:guid}")]
    public async Task StreamNotificationsAsync(Guid userId)
    {
        Response.ContentType = "text/event-stream";

        while (!HttpContext.RequestAborted.IsCancellationRequested)
        {
            var notifications = await _notificationService.GetAllNotReadAsync(userId);
            if (notifications != null && notifications.Any())
            {
                var jsonData = JsonConvert.SerializeObject(notifications);
                var data = $"data: {jsonData}\n\n";

                var bytes = Encoding.UTF8.GetBytes(data);
                await Response.Body.WriteAsync(bytes, 0, bytes.Length);
                await Response.Body.FlushAsync();

                await _notificationService.UpdateSetToSentNotifications(notifications.Select(x => x.Id));
            }

            await Task.Delay(5000);
        }
    }

    // [CustomAuthorize("Admin")]
    [HttpPut("read/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutSetReadNotificationAsync([FromRoute] Guid id)
    {
        await _notificationService.UpdateSetToReadNotification(id);
        return NoContent();
    }
}