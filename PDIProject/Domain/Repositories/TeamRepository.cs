using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly PDIDataContext _context;
        public TeamRepository(PDIDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.Where(x => !x.Deleted);
        }

        public Team GetById(int id)
        {
            return _context.Teams.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        public void Add(Team user)
        {
            _context.Teams.Add(user);
        }

        public IEnumerable<Team> GetAllByCompanyId(int companyId)
        {
            return _context.Teams.Where(x => x.Department.CompanyId == companyId && !x.Deleted);
        }
    }
}
