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
    }
}
