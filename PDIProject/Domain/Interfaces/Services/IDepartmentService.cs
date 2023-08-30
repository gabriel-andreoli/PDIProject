using PDIProject.Domain.Commands.DepartmentCommands;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IDepartmentService
    {
        void CreateDepartment(DepartmentCommand command);
        Department GetById(int id);
        List<Department> GetAllByCompanyId(int companyId);
    }
}
