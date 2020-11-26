﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project2.Entities;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private Project2.Services.IUserService _userService;

        public UsersController(Project2.Services.IUserService userService)
        {
            _userService = userService;
        }


        //POST: /users/authenticate
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            Console.WriteLine("okayyy");
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        //POST: /users/create
        [Authorize(Roles = Role.Admin)]
        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            var response = _userService.Create(user);
            
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        //GET: /users/all
        [Authorize(Roles = Role.Admin)]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        //GET: /users/{id}      {id} is int
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);


            if (user == null)
            {
                return NotFound(); //if they don't exist
            }

            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}