using PDIProject.Domain.DTOs.TaskJobDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.ExtensionMethods
{
    public static class UserExtension
    {
        public static TaskJobUserDTO ToTaskJobUserDTO(this User user)
        {
            return new TaskJobUserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                Photo = user.Photo,
                Email = user.Email,
                JobPositionName = user.JobPosition.Name,
                Habilities = null,
                TaskJobs = null
            };
        }
    }
}
