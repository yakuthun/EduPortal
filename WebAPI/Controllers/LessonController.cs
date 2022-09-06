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

        private readonly IGenericService<Lesson, LessonDto> _genericService;

        public LessonController(IGenericService<Lesson, LessonDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLesson()
        {
            return ActionResultInstance(await _genericService.GetAllAsync());
        }
    }
}
