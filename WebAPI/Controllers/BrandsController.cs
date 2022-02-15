using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _service;

        public BrandsController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var req = _service.GetAll();
            if (req.Success)
            {
                return Ok(req);
            }

            return BadRequest(req);
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(int id)
        {
            var req = _service.GetById(id);
            if (req.Success)
            {
                return Ok(req);
            }

            return BadRequest(req);
        }

        [HttpPost(nameof(Add))]
        public IActionResult Add(Brand brand)
        {
            var req = _service.Add(brand);
            if (req.Success) return Ok(req);
            return BadRequest(req);
        }

        [HttpPost(nameof(DeleteById))]
        public IActionResult DeleteById(int id)
        {
            var req = _service.DeleteById(id);
            if (req.Success) return Ok(req);
            return BadRequest(req);
        }

        [HttpPost(nameof(Update))]
        public IActionResult Update(Brand brand)
        {
            var req = _service.Update(brand);
            if (req.Success) return Ok(req);
            return BadRequest(req);
        }

        [HttpGet(nameof(Get))]
        public IActionResult Get(int id)
        {
            var req = _service.Get(id);
            if (req.Success) return Ok(req);
            return BadRequest(req);
        }

        [HttpGet(nameof(GetByName))]
        public IActionResult GetByName(string name)
        {
            var req = _service.GetByName(name);
            if (req.Success) return Ok(req);
            return BadRequest(req);
        }
    }
}