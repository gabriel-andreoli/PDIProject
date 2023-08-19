using PDIProject.Domain.Commands.JobPositionCommands;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface IJobPositionService
    {
        void CreateJobPosition(JobPositionCommand command);
    }
}
