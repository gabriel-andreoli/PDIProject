using PDIProject.Domain.Commands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IUnitOfWork unitOfWork, ICompanyRepository companyRepository) : base(unitOfWork)
        { 
            _companyRepository = companyRepository;
        }

        public IEnumerable<Company> GetAll() 
        {
            return _companyRepository.GetAll();
        }

        public Company GetById(int id) 
        {
            return _companyRepository.GetById(id);
        }

        public void CreateCompany(Company company)
        {
            var companyExists = _companyRepository.GetById(company.Id);
            if (companyExists != null)
                throw new ArgumentException("A empresa já está presente no Banco de Dados");
            _companyRepository.Add(company);
            Commit();
        }
    }
}
