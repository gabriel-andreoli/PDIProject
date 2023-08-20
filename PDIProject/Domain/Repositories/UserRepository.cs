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
                .Include(hu => hu.HabilitiesUser)
                .ThenInclude(h => h.Hability)
                .Include(tju => tju.TaskJobUsers)
                .ThenInclude(tj => tj.TaskJob)
                .Where(x => x.TeamId == teamId && !x.Deleted).ToList();
        }

        public User GetJobPositionByUserId(int userId) 
        {
            return _context.Users.Include(jb => jb.JobPosition).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }

        public User GetByIdWithTaskJob(int userId) 
        {
            return _context.Users.Include(tju => tju.TaskJobUsers).ThenInclude(tj => tj.TaskJob).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }

        public void CreateHability(Hability hability) 
        {
            _context.Habilities.Add(hability);
        }

        public Hability GetHabilityById(int habilityId)
        {
            return _context.Habilities.Where(x => x.Id == habilityId && !x.Deleted).FirstOrDefault();
        }

        public void AssignHabilityOnUser(HabilityUser habilityUser) 
        {
            _context.HabilitiesUsers.Add(habilityUser);
        }

        public User GetByIdWithHabilities(int userId) 
        {
            return _context.Users.Include(hu => hu.HabilitiesUser).ThenInclude(h => h.Hability).Where(x => x.Id == userId && !x.Deleted).FirstOrDefault();
        }
    }
}
