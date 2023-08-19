using PDIProject.Domain.Entities;
using System.ComponentModel.Design;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Team> GetAll();
        void Add(Team user);
        Team GetById(int id);
        IEnumerable<Team> GetAllByCompanyId(int companyId);
    }
}
