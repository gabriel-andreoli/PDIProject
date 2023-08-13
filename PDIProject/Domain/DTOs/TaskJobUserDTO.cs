using PDIProject.Domain.Entities;

namespace PDIProject.Domain.DTOs
{
    public class TaskJobUserDTO
    {
        public string Name { get; set; }
        public string? Photo { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Hability> Habilities { get; set; }
        public ICollection<TaskJob> TaskJobs { get; set; }
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public TaskJobUserDTO() { }
    }
}
