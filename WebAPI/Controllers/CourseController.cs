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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustmBaseController
    {
        private readonly IGenericService<Course, CourseDto> _courseService;

        public CourseController(IGenericService<Course, CourseDto> genericService)
        {
            _courseService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            return ActionResultInstance(await _courseService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveCourse(CourseDto courseDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.
            courseDto.CreatedDate = DateTime.Now;
            courseDto.UpdatedDate = DateTime.Now;
            courseDto.CreatedKey= userIdClaim.Value;
            courseDto.UpdatedKey = userIdClaim.Value;
            courseDto.IsDeleted = false;
           
            
            //courseDto.UpdatedKey = HttpContext.User.Identity.Name;
            return ActionResultInstance(await _courseService.AddAsync(courseDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto)
        {
             var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            courseDto.UpdatedKey= userIdClaim.Value;
            courseDto.UpdatedDate = DateTime.Now;
            //courseDto.CreatedDate = courseDto.CreatedDate;
            //courseDto.CreatedKey = courseDto.CreatedKey;
            courseDto.IsDeleted = false;

            return ActionResultInstance(await _courseService.Update(courseDto, courseDto.CourseID));
        }
        //api/product/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id, CourseDto courseDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            courseDto.IsDeleted = true;
            courseDto.CourseID = id;
            courseDto.DeletedKey = userIdClaim.Value;
            courseDto.DeletedDate = DateTime.Now;
            //courseDto.UpdatedKey = userIdClaim.Value;
            //courseDto.UpdatedDate = DateTime.Now;
            //courseDto.CategoryID = courseDto.CategoryID;
            return ActionResultInstance(await _courseService.SoftDelete(courseDto,id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _courseService.GetByIdAsync(id));
        }
    }
}
