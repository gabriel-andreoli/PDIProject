namespace PDIProject.Domain.Entities
{
    public class Department : BaseClass
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Team> Teams { get; set; }
        public Department()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            Teams = new List<Team>();
        }
    }

}
