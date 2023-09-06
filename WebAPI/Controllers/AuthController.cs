using Business.Abstract;
using Core.Entites.Concrete.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLoginResult = _authService.Login(userForLoginDto);
            if (!userToLoginResult.IsSuccess)
            {
                return BadRequest(userToLoginResult.Message);
            }

            var result = _authService.CreateAccessToken(userToLoginResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            

            var registerResult = _authService.Register(userForRegisterDto);

            if (!registerResult.IsSuccess)
            {
                return BadRequest(registerResult.Message);
            }

            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

    }
}
