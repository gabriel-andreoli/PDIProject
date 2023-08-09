namespace PDIProject.Domain.Entities
{
    public class Department : BaseClass
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public List<Team> Teams { get; set; }
        public Department()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }

}
