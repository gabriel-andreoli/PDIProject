using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Interfaces.Services;
using System.Net;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/taskjob")]
    public class TaskJobController : ControllerBase
    {
        private readonly ITaskJobService _taskJobService;
        private readonly IUserService _userService;

        public TaskJobController
            (
                ITaskJobService taskJobService,
                IUserService userService
            ) 
        {
            _taskJobService = taskJobService;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetByCompanyId(int companyId) 
        {
            var result = _taskJobService.GetByCompanyId(companyId);
            return StatusCode((int)HttpStatusCode.OK, result);
        }
    }
}
