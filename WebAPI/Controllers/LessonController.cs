using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : CustmBaseController
    {

        private readonly IGenericService<Lesson, LessonDto> _lessonService;
        private readonly IGenericService<Notification, NotificationDto> _notificationService;

        public LessonController(IGenericService<Lesson, LessonDto> genericService, IGenericService<Notification, NotificationDto> notificationService)
        {
            _lessonService = genericService;
            _notificationService = notificationService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLesson()
        {
            return ActionResultInstance(await _lessonService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveLesson(LessonDto lessonDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.
            lessonDto.CreatedDate = DateTime.Now;
            lessonDto.UpdatedDate = DateTime.Now;
            lessonDto.CreatedKey = userIdClaim.Value;
            lessonDto.UpdatedKey = userIdClaim.Value;
            lessonDto.IsDeleted = false;
            //NotificationDto not = new NotificationDto();
            //not.Message = "xx";
            //await _notificationService.AddAsync(not);
            //lessonDto.UpdatedKey = HttpContext.User.Identity.Name;
            return ActionResultInstance(await _lessonService.AddAsync(lessonDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLesson(LessonDto lessonDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            lessonDto.UpdatedKey = userIdClaim.Value;
            lessonDto.UpdatedDate = DateTime.Now;
            //lessonDto.CreatedDate = lessonDto.CreatedDate;
            //lessonDto.CreatedKey = userIdClaim.Value;
            lessonDto.IsDeleted = false;
            return ActionResultInstance(await _lessonService.Update(lessonDto, lessonDto.LessonID));
        }
        //api/product/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id, LessonDto lessonDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            lessonDto.IsDeleted = true;
            lessonDto.LessonID = id;
            lessonDto.DeletedKey = userIdClaim.Value;
            lessonDto.DeletedDate = DateTime.Now;
            lessonDto.UpdatedKey = userIdClaim.Value;
            lessonDto.UpdatedDate = DateTime.Now;
            return ActionResultInstance(await _lessonService.SoftDelete(lessonDto, id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _lessonService.GetByIdAsync(id));
        }
    }
}
