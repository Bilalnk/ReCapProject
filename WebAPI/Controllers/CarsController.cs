using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            if (_service.GetAll().Success)
            {
                return Ok(_service.GetAll());
            }

            return BadRequest(_service.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _service.Add(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}