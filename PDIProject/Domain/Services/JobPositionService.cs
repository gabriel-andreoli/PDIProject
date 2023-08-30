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
        private readonly IUserRepository _userRepository;
        public JobPositionService(IUnitOfWork unitOfWork, 
            IJobPositionRepository jobPositionRepository,
            IUserRepository userRepository) : base(unitOfWork)
        {
            _jobPositionRepository = jobPositionRepository;
            _userRepository = userRepository;
        }

        public List<JobPosition> GetAllJobPositionByCompanyId(int companyId)
        { 
            return _userRepository.GetAllJobPositionByCompanyId(companyId);
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
