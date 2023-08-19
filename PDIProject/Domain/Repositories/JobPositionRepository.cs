using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        private readonly PDIDataContext _context;
        public JobPositionRepository(PDIDataContext context)
        {
            _context = context;
        }

        public IEnumerable<JobPosition> GetAll()
        {
            return _context.JobPositions.Where(x => !x.Deleted);
        }

        public JobPosition GetById(int id)
        {
            return _context.JobPositions.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        public void Add(JobPosition jobPosition)
        {
            _context.JobPositions.Add(jobPosition);
        }
    }
}
