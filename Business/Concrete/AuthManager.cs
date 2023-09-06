using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Entites.Concrete.Dto;
using Core.Utitilies.BusinessRules;
using Core.Utitilies.Helpers.Security.Hashing;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using Core.Utitilies.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthServices
    {
        IUserServices _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserServices userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }



        [ValidationAspect(typeof(UserForLoginDtoValidator))]
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
           var ruleResult =  BusinessRules.Check
                (CheckIfUserExistForLogin(userForLoginDto.Email),
                CheckIfPasswordCorrect(userForLoginDto));
            if (!ruleResult.IsSuccess )
            {
                return new ErrorDataResult<User>();
            }

            User userToLogin = _userService.Get(u=> u.Email == userForLoginDto.Email).Data;
            return new SuccessDataResult<User>(userToLogin);
        }


        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var ruleResult = BusinessRules.Check(CheckIfUserExistForRegister(userForRegisterDto.Email));
            if (!ruleResult.IsSuccess)
            {
                return new ErrorDataResult<User>(ruleResult.Message);
            }




            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordSalt, out passwordHash);

            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.Registered);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaimsOfUser(user);
            var accessToken = _tokenHelper.CreateToken(user,claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken);
        }



        //RULES

        private IResult CheckIfUserExistForRegister(string email)
        {
            var result = _userService.Get(u=> u.Email == email);
            if (result.Data!= null)
            {
                return new ErrorResult("Aynı mail'de kullanıcı var");
            }
            return new SuccessResult("maile ait kullanıcı yok");
        }

        private IResult CheckIfUserExistForLogin(string email)
        {
            var result = _userService.Get(u => u.Email == email);
            if (result.Data == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");
            }
            return new SuccessResult("Kullanıcı mevcut");
        }

        private IResult CheckIfPasswordCorrect(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.Get(u=> u.Email == userForLoginDto.Email).Data;
            var result = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash);
            if (!result.IsSuccess)
            {
                return new ErrorResult("Hatalı parola");
            }
            return new SuccessResult();
        }

        
    }
}
