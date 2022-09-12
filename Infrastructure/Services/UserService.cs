using Application.Dto;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Domain.Entities;
using Infrastructure.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(UserManager<UserApp> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        //yeni bir kullanıcı oluşturuyor
        public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new UserApp
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
                Name = createUserDto.Name,
                SurName = createUserDto.SurName
            };

            
            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();//username already taken gibi hatalar dönecek
                return Response<UserAppDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> DeleteUserAsync(UserDeleteDto userDto)
        {
            
           
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<UserAppDto>>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserAppDto>> GetUserByNameAsync(string userName)
        {//username ile beraber yeni bir user döneceğiz.
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }
            return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
        }

        public async Task<Response<UserAppDto>> UpdateUserAsync(UpdateUserDto userDto,string userName)
        {

            var users = await _userManager.FindByNameAsync(userName);
            if (users == null)
            {
                return Response<UserAppDto>.Fail("UserName not found", 404, true);
            }
            else
            {
                var user = new UserApp
                {
                    Name = userDto.Name,
                    SurName = userDto.SurName,
                    Picture = userDto.Picture,
                    Skills = userDto.Skills
                };


                await _userManager.UpdateAsync(user);
                return Response<UserAppDto>.Success(ObjectMapper.Mapper.Map<UserAppDto>(user), 200);
            }



        }
    }
}
