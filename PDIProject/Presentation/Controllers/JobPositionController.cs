
using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.JobPositionCommands;
using PDIProject.Domain.Interfaces.Services;
using System.Net;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/jobposition")]
    public class JobPositionController : ControllerBase
    {
        private readonly IJobPositionService _jobPositionService;

        public JobPositionController(IJobPositionService jobPositionService) 
        { 
            _jobPositionService = jobPositionService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateJobPosition(JobPositionCommand command) 
        {
            _jobPositionService.CreateJobPosition(command);
            return StatusCode(201);
        }
    }
}
