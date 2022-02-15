using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}