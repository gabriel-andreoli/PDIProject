using PDIProject.Domain.Enums;

namespace PDIProject.Domain.Entities
{
    public class TaskJob : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ETaskJobStatus Status { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public ICollection<User> Users { get; set; }
        public TaskJob() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            Requirements = new List<Requirement>();
            Users = new List<User>();
        }
        
    }
}
