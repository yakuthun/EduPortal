using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustmBaseController
    {
        private readonly IGenericService<Category,CategoryDto> _genericService;

        public CategoryController(IGenericService<Category, CategoryDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return ActionResultInstance(await _genericService.GetAllAsync());
        }
    }
}
