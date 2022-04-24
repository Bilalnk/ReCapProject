#region info

// Bilal Karataş20220424

#endregion

using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExists(userForRegisterDto.Email);
            if (userExist.Success)
            {
                return BadRequest(userExist.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var createdToken = _authService.CreateAccessToken(registerResult.Data);
            if (createdToken.Success)
            {
                return Ok(createdToken.Data);
            }

            return BadRequest(createdToken.Message);
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var accessToken = _authService.CreateAccessToken(userToLogin.Data);
            if (accessToken.Success)
            {
                return Ok(accessToken.Data);
            }

            return BadRequest(accessToken.Message);
        }
    }
}