using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface ITaskJobRepository
    {
        void AddTaskJobUser(TaskJobUser obj);
        void Add(TaskJob taskJob);
        TaskJob GetById(int id);
        List<Ability> GetAllRequirementsByCompanyId(int companyId);
        void AddRequirement(Requirement requirement);
        List<TaskJob> GetAllByTeamId(int teamId);
        List<TaskJob> GetAllCompletedByTeamId(int teamId);
        List<TaskJob> GetAllPendingByTeamId(int teamId);
        List<TaskJob> GetAllLateByTeamId(int teamId);
    }
}
