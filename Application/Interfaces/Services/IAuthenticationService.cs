using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        //kullanıcıdan username ve passwordu alacağım ve doğruysa token döndereceğim.
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);//başarılı ise dönüş yapar.
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        //refresh token ile yeni bir token alabilir.

        Task<Response<NoContentDto>> RevokeRefreshToken(string refreshToken);//logout olursa null yapar.

        //task kaldırıldı async değil.
        Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto loginDto);
        //api'nin appsettings.json'unda client verilerini tutacağız.
    }
}
