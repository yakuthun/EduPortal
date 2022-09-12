using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustmBaseController
    {
        private readonly IGenericService<Category,CategoryDto> _categoryservice;
        private readonly ICategoryService<Category,CategoryDto> _categoryx;
        //private readonly ICategoryService<Category,CategoryDto> _testCategoryService;
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
        public async Task<IActionResult> SaveCategory(CategoryDto categoryDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.
            categoryDto.CreatedDate = DateTime.Now;
            categoryDto.UpdatedDate = DateTime.Now;
            categoryDto.CreatedKey= userIdClaim.Value;
            categoryDto.UpdatedKey = userIdClaim.Value;
            categoryDto.IsDeleted = false;
            
            //categoryDto.UpdatedKey = HttpContext.User.Identity.Name;
            return ActionResultInstance(await _categoryservice.AddAsync(categoryDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            categoryDto.UpdatedKey= userIdClaim.Value;
            categoryDto.UpdatedDate = DateTime.Now;
            //categoryDto.CreatedDate = categoryDto.CreatedDate;
            //categoryDto.CreatedKey = userIdClaim.Value;
            categoryDto.IsDeleted = false;
            return ActionResultInstance(await _categoryservice.Update(categoryDto, categoryDto.CategoryID));
        }
        //api/product/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, CategoryDto categoryDto)
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            categoryDto.IsDeleted = true;
            categoryDto.CategoryID = id;
            categoryDto.DeletedKey = userIdClaim.Value;
            categoryDto.DeletedDate = DateTime.Now;
            categoryDto.UpdatedKey = userIdClaim.Value;
            categoryDto.UpdatedDate = DateTime.Now;
            return ActionResultInstance(await _categoryservice.SoftDelete(categoryDto,id));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _categoryservice.GetByIdAsync(id));
        }

    }
}
