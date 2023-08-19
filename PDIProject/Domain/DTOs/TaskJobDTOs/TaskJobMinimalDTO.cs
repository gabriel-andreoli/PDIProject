using PDIProject.Domain.Enums;

namespace PDIProject.Domain.DTOs.TaskJobDTOs
{
    public class TaskJobMinimalDTO
    {
        public int Id { get; set; }
        public string TaskJobName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
