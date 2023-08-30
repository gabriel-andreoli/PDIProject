using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PDIDataContext _context;
        public UserRepository(PDIDataContext context) 
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() 
        {
            return _context.Users.Where(x => !x.Deleted);
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        public void Add(User user) 
        {
            _context.Users.Add(user);
        }

        public List<User> GetAllByTeamId(int teamId)
        {
            return _context.Users
                .Include(jb => jb.JobPosition)
                .Include(hu => hu.AbilitiesUsers)
                .ThenInclude(h => h.Ability)
                .Include(tju => tju.TaskJobsUsers)
                .ThenInclude(tj => tj.TaskJob)
                .ThenInclude(r => r.Requirements)
                .Where(x => x.TeamId == teamId && !x.Deleted).ToList();
        }

        public User GetJobPositionByUserId(int userId) 
        {
            return _context.Users.Include(jb => jb.JobPosition).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }

        public List<JobPosition> GetAllJobPositionByCompanyId(int companyId)
        {
            return _context.JobPositions.Where(x => x.CompanyId == companyId && !x.Deleted).ToList();
        }

        public User GetByIdWithTaskJob(int userId) 
        {
            return _context.Users.Include(tju => tju.TaskJobsUsers).ThenInclude(tj => tj.TaskJob).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }

        public void CreateAbility(Ability ability) 
        {
            _context.Abilities.Add(ability);
        }

        public Ability GetAbilityById(int abilityId)
        {
            return _context.Abilities.Where(x => x.Id == abilityId && !x.Deleted).FirstOrDefault();
        }

        public void AssignAbilityOnUser(AbilityUser abilityUser) 
        {
            _context.AbilitiesUsers.Add(abilityUser);
        }

        public User GetByIdWithAbilities(int userId) 
        {
            return _context.Users.Include(hu => hu.AbilitiesUsers).ThenInclude(h => h.Ability).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }
    }
}
