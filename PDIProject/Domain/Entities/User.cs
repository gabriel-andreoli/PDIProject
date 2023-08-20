namespace PDIProject.Domain.Entities
{
    public class User : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string? Photo { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<AbilityUser> AbilitiesUsers { get; set; }
        public ICollection<TaskJobUser> TaskJobsUsers { get; set; }
        public int JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }
        public User() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            AbilitiesUsers = new List<AbilityUser>();
            TaskJobsUsers = new List<TaskJobUser>();
        }
    }
}
