using PDIProject.Domain.Enums;

namespace PDIProject.Domain.DTOs.TaskJobDTOs
{
    public class TaskJobMinimalDTO
    {
        public string TaskJobName { get; set; }
        public string Description { get; set; }
        public ETaskJobStatus Status { get; set; }
    }
}
