using PDIProject.Domain.Commands.JobPositionCommands;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IJobPositionService
    {
        List<JobPosition> GetAllJobPositionByCompanyId(int companyId);
        void CreateJobPosition(JobPositionCommand command);
    }
}
