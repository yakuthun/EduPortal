using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {//burası direkt olarak Presentation Layer(API) ile haberleşecek
        Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto userDto);
        Task<Response<UserAppDto>> GetUserByNameAsync(string userName);//user bilgilerini alacak
        Task<Response<UserAppDto>> UpdateUserAsync(UpdateUserDto userDto,string userName);
        Task<Response<UserAppDto>> DeleteUserAsync(UserDeleteDto userDto);
        Task<Response<IEnumerable<UserAppDto>>> GetAllUserAsync();//user bilgilerini alacak
        
    }
}
