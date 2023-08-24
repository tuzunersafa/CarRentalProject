using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageServices _carImageServices;
        public CarImagesController(ICarImageServices carImageServices)
        {
            _carImageServices = carImageServices;

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageServices.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _carImageServices.Get(c => c.Id == id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpGet("GetByCarId")]
        public IActionResult GetByCarId(int id)
        {
            var result = _carImageServices.GetAll(c => c.CarId == id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("Add")]
        public IActionResult Add(IFormFile file)
        {
            //var result = _carImageServices.Add(carImage);
            //if (result.IsSuccess)
            //{
            //    return Ok(result);
            //}
            //return BadRequest(result);
            return Ok();
        }


        //[HttpPost("Update")]
        //public IActionResult Update(CarImage carImage)
        //{
        //    var result = _carImageServices.Update(carImage);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}


        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageServices.Delete(carImage);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }


}

