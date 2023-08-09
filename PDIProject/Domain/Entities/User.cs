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
        public Department Deparment { get; set; }
        public ICollection<Hability> Habilities { get; set; }
        public ICollection<TaskJob> TaskJobs { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public User() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
