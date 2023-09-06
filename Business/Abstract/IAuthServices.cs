using Core;
using Core.Entites.Concrete;
using Core.Entites.Concrete.Dto;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthServices
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<AccessToken> CreateAccessToken(User user);


    }
}