using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.DepartmentCommands;
using PDIProject.Domain.Interfaces.Services;

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

        [HttpPost]
        public IActionResult CreateDepartment(DepartmentCommand command)
        {
            _departmentService.CreateDepartment(command);
            return StatusCode(201);
        }

    }
}
