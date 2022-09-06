using Application.Configuration;
using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);//usere özgü token oluşturacağız
        ClientTokenDto CreateTokenByClient(Client client);//client id ve client secret bulunduruyor
    }
}
