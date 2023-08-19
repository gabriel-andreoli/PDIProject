namespace PDIProject.Domain.Entities
{
    public class JobPosition : BaseClass
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public int CompanyId { get; set; }
        public JobPosition()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            Users = new List<User>();
        }
    }
}
