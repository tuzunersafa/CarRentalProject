﻿using Business.Abstract;
using Core.Entites.Concrete;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServices _userService;
        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var result = _userService.Get(u => u.Id == id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetClaimsOfUser")]
        public IActionResult GetClaimsOfUser(int userId)
        {
            var _user = _userService.Get(u => u.Id == userId).Data;

            var result = _userService.GetClaimsOfUser(_user);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




    }      
}

