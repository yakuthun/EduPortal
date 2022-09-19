using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CustmBaseController
    {
        private readonly IUserService _userService;
        private readonly UserManager<UserApp> _userManager;
        public UserController(IUserService userService, UserManager<UserApp> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        //api/user
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            //throw new CustomException("Veritabanı ile ilgili bir hata meydana geldi");//exception fırlatacağız.
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        [Authorize]//bu endpoint mutlaka bir token istiyor.
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        }
        [Authorize]

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDto updateUserDto)
        {
           return ActionResultInstance(await _userService.UpdateUserAsync(updateUserDto, HttpContext.User.Identity.Name));
        }
    }
}
