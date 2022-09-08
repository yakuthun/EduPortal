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
        private readonly ICategoryService<Category,CategoryDto> _testCategoryService;
        public CategoryController(IGenericService<Category, CategoryDto> genericService, ICategoryService<Category,CategoryDto> testCategoryService)
        {
            _categoryservice = genericService;
            _testCategoryService = testCategoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return ActionResultInstance(await _categoryservice.GetAllAsync());
        }
        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryDto categoryDto)
        {
            return ActionResultInstance(await _categoryservice.AddAsync(categoryDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            return ActionResultInstance(await _categoryservice.Update(categoryDto, categoryDto.CategoryID));
        }
        //api/product/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return ActionResultInstance(await _categoryservice.Remove(id));
        }

        //[HttpPost]
        //public async Task<IActionResult> SaveTestCategory(CategoryDto categoryDto)
        //{
        //    return ActionResultInstance(await _testCategoryService.AddCategoryAsync(categoryDto));
        //}
    }
}
