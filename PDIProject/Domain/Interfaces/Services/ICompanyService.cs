using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        Company GetBydId(int id);
        void CreateCompany(Company company);
    }
}
