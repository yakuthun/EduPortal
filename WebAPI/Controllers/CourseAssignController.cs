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
        private readonly INotificationService _notification;
        public CourseAssignController(IGenericService<CourseAssign, CourseAssignDto> assignService,INotificationService notification)
        {
            _assignService = assignService;
            _notification = notification;
        }

        [HttpPost]
        public async Task<IActionResult> CourseAssign(CourseAssignDto courseAssignDto)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //courseAssignDto.TeamLeadKey = userIdClaim.Value;
            await _notification.AddNotificationAsync("A new course has been assigned to you",courseAssignDto.AssignKey);
            return ActionResultInstance(await _assignService.AddAsync(courseAssignDto));
        }

        [HttpPut]
        public async Task<IActionResult> CourseAssignUpdate(CourseAssignDto course)
        {
            await _notification.AddNotificationAsync("Team Lead Change", course.AssignKey);
            return ActionResultInstance(await _assignService.Update(course,course.CourseAssignID));
        }
    }
}