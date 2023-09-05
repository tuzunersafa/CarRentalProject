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

        [HttpPost("UploadImage")]
        public IActionResult UploadImage(IFormFile imageFile, int carId)
        {
            var result = _carImageServices.Upload(imageFile, carId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest();
        }





        //[HttpPost("Add")]
        //public IActionResult Add(CarImage carImage)
        //{
        //    var result = _carImageServices.Add(carImage);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
            
        //}


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


        [HttpPost("DeleteById")]
        public IActionResult Delete(int id)
        {
            var imageToDelete = _carImageServices.Get(i=> i.Id == id).Data;
            var result = _carImageServices.Delete(imageToDelete);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }


}

