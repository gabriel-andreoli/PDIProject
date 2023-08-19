using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface IJobPositionRepository
    {
        IEnumerable<JobPosition> GetAll();
        JobPosition GetById(int id);
        void Add(JobPosition jobPosition);
    }
}
