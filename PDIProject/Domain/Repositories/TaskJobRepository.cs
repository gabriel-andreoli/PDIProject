using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class TaskJobRepository : ITaskJobRepository
    {
        private readonly PDIDataContext _context;
        public TaskJobRepository(PDIDataContext context)
        {
            _context = context;
        }

        public void AddTaskJobUser(TaskJobUser obj) 
        {
            _context.TaskJobsUsers.Add(obj);
        }

        public void Add(TaskJob taskJob) 
        {
            _context.TaskJobs.Add(taskJob);
        }

        public TaskJob GetById(int id) 
        {
            return _context.TaskJobs.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        public List<Ability> GetAllRequirementsByCompanyId(int companyId)
        {
            return _context.Abilities.Where(x => x.CompanyId == companyId && !x.Deleted).ToList();
        }

        public void AddRequirement(Requirement requirement)
        {
            _context.Requirements.Add(requirement);
        }

        public List<TaskJob> GetAllByTeamId(int teamId)
        {
            return _context.TaskJobs.Where(x => x.TeamId == teamId && !x.Deleted).ToList();
        }

        public List<TaskJob> GetAllCompletedByTeamId(int teamId)
        {
            return _context.TaskJobs.Where(x => x.TeamId == teamId && !x.Deleted && x.Status == Enums.ETaskJobStatus.Completed).ToList();
        }

        public List<TaskJob> GetAllPendingByTeamId(int teamId)
        {
            return _context.TaskJobs.Where(x => x.TeamId == teamId && !x.Deleted && x.Status == Enums.ETaskJobStatus.Pending).ToList();
        }

        public List<TaskJob> GetAllLateByTeamId(int teamId)
        {
            return _context.TaskJobs.Where(x => x.TeamId == teamId && !x.Deleted && x.Status == Enums.ETaskJobStatus.Late).ToList();
        }
    }
}
