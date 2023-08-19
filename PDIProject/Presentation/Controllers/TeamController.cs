using Microsoft.AspNetCore.Mvc;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/company")]
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

        }
    }
}
