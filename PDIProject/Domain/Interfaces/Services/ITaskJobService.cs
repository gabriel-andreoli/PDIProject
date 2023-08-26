using PDIProject.Domain.Commands.TaskJobCommands;
using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface ITaskJobService
    {
        TaskJobsByCompanyIdDTO GetByCompanyId(int companyId);
        void CreateTaskJob(TaskJobCommand command);
        void AssignTaskJobOnUser(TaskJobUserCommand command);
        List<Ability> GetAllRequirementsByCompanyId(int companyId);
    }
}
