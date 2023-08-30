using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.DepartmentCommands;
using PDIProject.Domain.Interfaces.Services;
using System.Net;

namespace PDIProject.Presentation.Controllers
{
    [ApiController]
    [Route("v1/department")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllByCompanyId(int companyId)
        {
            var result = _departmentService.GetAllByCompanyId(companyId);
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("")]
        public IActionResult CreateDepartment(DepartmentCommand command)
        {
            _departmentService.CreateDepartment(command);
            return StatusCode(201);
        }

    }
}
