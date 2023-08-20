using PDIProject.Domain.Enums;

namespace PDIProject.Domain.Entities
{
    public class TaskJob : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ETaskJobStatus Status { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int TeamId { get; set; }
        public ICollection<TaskJobUser> TaskJobUsers { get; set; }
        public TaskJob() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            TaskJobUsers = new List<TaskJobUser>();
        }
        
    }
}
