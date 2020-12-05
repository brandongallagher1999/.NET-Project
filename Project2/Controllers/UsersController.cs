using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project2.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;

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
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000/");
            Console.WriteLine("authentication");
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });


            string key = "token";
            string value = user.Token; // their JWT
            HttpContext.Response.Cookies.Append(key, value);



            return Ok(user);
        }

        //POST: /users/create
        [Authorize(Roles = Role.Admin)]
        [Route("create")]
        [HttpPost]
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

        //DELETE: /users/delete/{username}
        // Deletes a user.
        [Authorize(Roles = Role.Admin)]
        [Route("delete/{username}")]
        [HttpDelete]
        public IActionResult Delete(string username)
        {
            var response = _userService.DeleteUser(username);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        //PUT /users/update/{username}
        //JsonBody: NewUser
        [Authorize(Roles = Role.Admin)]
        [Route("update/{username}")]
        [HttpPut]
        public IActionResult Update(string username, [FromBody] NewUser newUser)
        {
            var response = _userService.Update(username, newUser);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        //GET: /users/{username}      {username} is a string
        [HttpGet("{username}")]
        public IActionResult GetById(string username)
        {
            var user = _userService.GetById(username);


            if (user == null)
            {
                return NotFound(); //if they don't exist
            }

            //var currentUserId = int.Parse(User.Identity.Name);
            if (!User.IsInRole(Role.Admin))
            {
                return Forbid();
            }

            return Ok(user);
        }
    }
}