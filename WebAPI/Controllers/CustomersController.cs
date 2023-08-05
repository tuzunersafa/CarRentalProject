using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerServices _customerService;
        public CustomersController(ICustomerServices customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.Get(cust => cust.Id == id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
