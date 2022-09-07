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
        private readonly IGenericService<Category,CategoryDto> _categoryservice;

        public CategoryController(IGenericService<Category, CategoryDto> genericService)
        {
            _categoryservice = genericService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return ActionResultInstance(await _categoryservice.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveProduct(CategoryDto categoryDto)
        {
            return ActionResultInstance(await _categoryservice.AddAsync(categoryDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(CategoryDto categoryDto)
        {
            return ActionResultInstance(await _categoryservice.Update(categoryDto, categoryDto.CategoryID));
        }
        //api/product/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return ActionResultInstance(await _categoryservice.Remove(id));
        }
    }
}
