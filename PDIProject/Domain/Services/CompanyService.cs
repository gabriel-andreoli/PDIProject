using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;

namespace PDIProject.Domain.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) 
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
                throw new ArgumentException("O usuário já está presente no Banco de Dados");
            _companyRepository.Add(company);
        }
    }
}
