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
    public class LessonController : CustmBaseController
    {

        private readonly IGenericService<Lesson, LessonDto> _lessonService;

        public LessonController(IGenericService<Lesson, LessonDto> genericService)
        {
            _lessonService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLesson()
        {
            return ActionResultInstance(await _lessonService.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(LessonDto lessonDto)
        {
            return ActionResultInstance(await _lessonService.AddAsync(lessonDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(LessonDto lessonDto)
        {
            return ActionResultInstance(await _lessonService.Update(lessonDto, lessonDto.LessonID));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return ActionResultInstance(await _lessonService.Remove(id));
        }
    }
}
