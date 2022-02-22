using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private IRentalService _service;

        public RentalsController(IRentalService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetByCarId))]
        public IActionResult GetByCarId(int carId)
        {
            var result = _service.GetByCarId(carId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet(nameof(GetByCustomerId))]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _service.GetByCustomerId(customerId);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(Rental rental)
        {
            var result = _service.Add(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(Rental rental)
        {
            var result = _service.Delete(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update(Rental rental)
        {
            var result = _service.Update(rental);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}