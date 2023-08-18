using PDIProject.Domain.Commands;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();
        Company GetById(int id);
        void Add(Company company);
    }
}
