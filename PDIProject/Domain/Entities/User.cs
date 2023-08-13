namespace PDIProject.Domain.Entities
{
    public class User : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
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
        public User() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            Habilities = new List<Hability>();
            TaskJobs = new List<TaskJob>();
        }
    }
}
