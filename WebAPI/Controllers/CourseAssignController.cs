using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "TeamLead")]
    [ApiController]
    public class CourseAssignController : CustmBaseController
    {
        private readonly IGenericService<CourseAssign, CourseAssignDto> _assignService;
        private readonly IGenericService<Notification, NotificationDto> _notificationService;
        NotificationDto notification = new NotificationDto();
        public CourseAssignController(IGenericService<CourseAssign, CourseAssignDto> assignService, IGenericService<Notification, NotificationDto> notificationService)
        {
            _assignService = assignService;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveLesson(CourseAssignDto courseAssignDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            courseAssignDto.TeamLeadKey = userIdClaim.Value;

            notification.Message = "A new course has been assigned to you";
            notification.CreatedDate = DateTime.Now;
            notification.UserKey= courseAssignDto.AssignKey;
            await _notificationService.AddAsync(notification);
            //lessonDto.UpdatedKey = HttpContext.User.Identity.Name;
            return ActionResultInstance(await _assignService.AddAsync(courseAssignDto));
        }
    }
}
