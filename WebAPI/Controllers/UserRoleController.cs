using Application.Dto;
using AutoMapper.Internal.Mappers;
using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserRoleController : ControllerBase
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly RoleManager<UserAppRole> _roleManager;
        protected UserApp CurrentUser => _userManager.FindByNameAsync(User.Identity.Name).Result;
        public UserRoleController(RoleManager<UserAppRole> roleManager, UserManager<UserApp> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //public async Task<IActionResult> RoleAssign(string id)
        //{
        //    UserApp user = await _userManager.FindByIdAsync(id);
          

        //    return NoContent();
        //}
        [HttpPut]
        public async Task<ActionResult> RoleAssign(List<RoleAssignViewModel> modelList, string id)
        {
            UserApp user = await _userManager.FindByIdAsync(id);
            List<UserAppRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignViewModel> assignRoles = new List<RoleAssignViewModel>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignViewModel
            {
                Exist = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            foreach (RoleAssignViewModel role in modelList)
            {
                if (role.Exist)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return NoContent();
        }
    }
}