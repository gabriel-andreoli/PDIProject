using PDIProject.Domain.Commands.DepartmentCommands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class DepartmentService : ServiceBase, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ICompanyRepository _companyRepository;
        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, ICompanyRepository companyRepository) : base(unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _companyRepository = companyRepository;
        }
        public void CreateDepartment(DepartmentCommand command)
        {
            var company = _companyRepository.GetById(command.CompanyId);

            if (company == null)
                throw new ArgumentNullException($"{nameof(company)} is null");

            var department = new Department()
            {
                Name = command.Name,
                Company = company
            };
            _departmentRepository.CreateDepartment(department);
            Commit();
        }
        public Department GetById(int id) 
        {
            return _departmentRepository.GetById(id);
        }

        public List<Department> GetAllByCompanyId(int companyId)
        {
            return _departmentRepository.GetAllByCompanyId(companyId);
        }
    }
}
