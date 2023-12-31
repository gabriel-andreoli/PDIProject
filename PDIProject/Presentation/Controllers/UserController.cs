﻿using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.HabilityCommands;
using PDIProject.Domain.Commands.UserCommands;
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
        public IActionResult GetAllByCompanyId(int companyId) 
        {
            var users = _userService.GetAllByCompanyId(companyId);
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

        [HttpPost]
        [Route("")]
        public IActionResult CreateUser(UserCommand user) 
        {
            _userService.CreateUser(user);
            return StatusCode((int)HttpStatusCode.Created, "Usuário criado com sucesso!");
        }

        [HttpPost]
        [Route("hability")]
        public IActionResult CreateAbility(AbilityCommand command)
        {
            _userService.CreateAbility(command);
            return StatusCode((int)HttpStatusCode.Created, "Habilidade criada com sucesso!");
        }

        [HttpPost]
        [Route("hability/assign")]
        public IActionResult AssignHabilityOnUser(AbilityUserCommand command)
        {
            _userService.AssignAbilityOnUser(command);
            return StatusCode((int)HttpStatusCode.Created, "Usuário vinculado com a habilidade com sucesso!");
        }

    }
}
