using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly PDIDataContext _context;
        public DepartmentRepository(PDIDataContext context)
        {
            _context = context;
        }

        public Department GetById(int id)
        {
            return _context.Departments.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }
        public void CreateDepartment(Department department)
        {
            _context.Departments.Add(department);
        }
    }
}
