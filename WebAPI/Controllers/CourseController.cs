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
        private readonly IGenericService<Course, CourseDto> _genericService;

        public CourseController(IGenericService<Course, CourseDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCourse()
        {
            return ActionResultInstance(await _genericService.GetAllAsync());
        }
    }
}
