using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Commands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly PDIDataContext _context;
        public CompanyRepository(PDIDataContext context) 
        { 
            _context = context;
        }

        public IEnumerable<Company> GetAll() 
        {
            return _context.Companies.Where(x => !x.Deleted).AsNoTracking();
        }

        public Company GetById(int id) 
        {
            return _context.Companies.FirstOrDefault(x => x.Id == id && !x.Deleted);
        }

        public void Add(Company company)
        {
            _context.Add(company);
        }
    }
}
