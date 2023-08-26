using PDIProject.Domain.DTOs.RequirementDTOs;
using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;
using PDIProject.Domain.Enums;
using PDIProject.Domain.Enums.Extensions;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class TaskJobExtension
    {
        public static TaskJobMinimalDTO ToTaskJobMinimalDTO(this TaskJob taskJob) 
        {
            return new TaskJobMinimalDTO()
            {
                Id = taskJob.Id,
                TaskJobName = taskJob.Name,
                Description = taskJob.Description,
                Status = taskJob.Status.GetDescription(),
                Requirements = new List<RequirementDTO>()
            };
        }
    }
}
