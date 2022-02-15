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


        [HttpGet(nameof(GetAllByBrandId))]
        public IActionResult GetAllByBrandId(int brandId)
        {
            var result = _service.GetAllByBrandId(brandId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(nameof(GetByModelYear))]
        public IActionResult GetByModelYear(int year)
        {
            var result = _service.GetByModelYear(year);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(nameof(GetCarDetails))]
        public IActionResult GetCarDetails()
        {
            var result = _service.GetCarDetails();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete(nameof(DeleteById))]
        public IActionResult DeleteById(int id)
        {
            var result = _service.DeleteById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(Car car)
        {
            var result = _service.Update(car);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}