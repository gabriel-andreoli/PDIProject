using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        void CreateDepartment(Department department);
        Department GetById(int id);
        List<Department> GetAllByCompanyId(int companyId);
    }
}
