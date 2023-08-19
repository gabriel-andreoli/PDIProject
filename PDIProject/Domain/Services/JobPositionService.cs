using PDIProject.Domain.Commands.JobPositionCommands;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Domain.Interfaces.Services;
using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public class JobPositionService : ServiceBase, IJobPositionService
    {
        private readonly IJobPositionRepository _jobPositionRepository;
        public JobPositionService(IUnitOfWork unitOfWork, IJobPositionRepository jobPositionRepository) : base(unitOfWork)
        {
            _jobPositionRepository = jobPositionRepository;
        }
        public void CreateJobPosition(JobPositionCommand command)
        {
            var newJobPosition = new JobPosition() 
            {
                Name = command.Name,
                CompanyId = command.CompanyId
            };
            _jobPositionRepository.Add(newJobPosition);
            Commit();
        }
    }
}
