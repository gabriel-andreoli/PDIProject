using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface ITaskJobService
    {
        TaskJobUserDTO GetInfoAndTaskJobsByUserId(int userId);
    }
}
