using Business.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarServices _carService;
        public CarsController(ICarServices carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           var result = _carService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }
        
        
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carService.Get(c=>c.Id == id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpGet("GetCarDetailsById")]
        public IActionResult GetCarDetailsById(int id)
        {
            var result = _carService.GetCarDetailsById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpGet("GetAllDetailed")]
        public IActionResult GetAllDetailed()
        {
            var result = _carService.GetCarsDetails();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        
        
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpPost("Update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        
        [HttpPost("Delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
