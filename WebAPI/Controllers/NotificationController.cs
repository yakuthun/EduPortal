using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : CustmBaseController
    {
        private readonly IGenericService<Notification, NotificationDto> _notificationService;
        private readonly INotificationService _notification;
        public NotificationController(IGenericService<Notification, NotificationDto> notificationService, INotificationService notification)
        {
            _notificationService = notificationService;
            _notification = notification;
        }

        //public async Task<IActionResult> GetNotification()
        //{
        //    NotificationDto p = new NotificationDto();
        //    return ActionResultInstance(await _notification.GetNotification(HttpContext.User.Identity.Name));
        //}
    }
}
