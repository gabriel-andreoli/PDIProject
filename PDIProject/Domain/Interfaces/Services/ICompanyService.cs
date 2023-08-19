using Microsoft.AspNetCore.Mvc;
using PDIProject.Domain.Commands.CompanyCommands;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();
        Company GetById(int id);
        void CreateCompany(CompanyCommand company);
    }
}
