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
            _context.TaskJobUsers.Add(obj);
        }

        public void Add(TaskJob taskJob) 
        {
            _context.TaskJobs.Add(taskJob);
        }

        public TaskJob GetById(int id) 
        {
            return _context.TaskJobs.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }
    }
}
