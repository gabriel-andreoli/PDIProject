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

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id) 
        {
            var user = _userService.GetBydId(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetMinimalById(int id)
        //{
        //    var user = _userService.GetBydId(id);

        //    if (user == null)
        //        return NotFound();

        //    return Ok(user);
        //}

        [HttpPost]
        [Route("")]
        public IActionResult CreateUser(User user) 
        {
            _userService.CreateUser(user);
            return StatusCode((int)HttpStatusCode.Created, "Usuário criado com sucesso!");
        }
    }
}
