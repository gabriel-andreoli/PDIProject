namespace PDIProject.Domain.Entities
{
    public class TaskJobUser : BaseClass
    {
        public int TaskJobId { get; set; }
        public TaskJob TaskJob { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime AssignmentDate { get; set; }
        public TaskJobUser() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
