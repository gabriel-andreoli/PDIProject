using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.TeamCommands;
using PDIProject.Domain.Interfaces.Services;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/team")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService) 
        {
            _teamService = teamService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateTeam(TeamCommand command) 
        { 
            _teamService.CreateTeam(command);
            return StatusCode(201);
        }
    }
}
