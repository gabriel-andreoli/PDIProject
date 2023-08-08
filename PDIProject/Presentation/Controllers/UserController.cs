using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Services;
using System.Net;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll() 
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateUser(User user) 
        {
            _userService.CreateUser(user);
            return StatusCode((int)HttpStatusCode.Created, "Usuário criado com sucesso!");
        }
    }
}
