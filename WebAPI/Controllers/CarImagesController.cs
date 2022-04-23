#region info

// Bilal Karataş20220329

#endregion

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add([FromForm] WrapperInput wrapperInput)
        {
            var result = _carImageService.Add(wrapperInput.File, wrapperInput.CarImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(nameof(GetByCarId))]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(nameof(Update))]
        public IActionResult Update([FromForm] WrapperInput wrapperInput)
        {
            var result = _carImageService.Update(wrapperInput.File, wrapperInput.CarImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        public class WrapperInput
        {
            public CarImage CarImage { get; set; }
            public IFormFile File { get; set; }
        }
    }
}