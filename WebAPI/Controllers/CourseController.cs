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
            return ActionResultInstance(await _courseService.AddAsync(courseDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(CourseDto courseDto)
        {
            return ActionResultInstance(await _courseService.Update(courseDto, courseDto.CourseID));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            return ActionResultInstance(await _courseService.Remove(id));
        }
    }
}
