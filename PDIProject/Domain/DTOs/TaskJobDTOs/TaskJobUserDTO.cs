using PDIProject.Domain.DTOs.HabilityDTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs.TaskJobDTOs
{
    public class TaskJobUserDTO
    {
        public string Name { get; set; }
        public string? Photo { get; set; }
        public string Email { get; set; }
        public ICollection<HabilityDTO> Habilities { get; set; }
        public ICollection<TaskJobMinimalDTO> TaskJobs { get; set; }
        public string JobPositionName { get; set; }
        public TaskJobUserDTO() { }
    }
}
