namespace PDIProject.Domain.Entities
{
    public class Requirement : BaseClass
    {
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<TaskJob> TaskJobs { get; set; }
        public Requirement() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
