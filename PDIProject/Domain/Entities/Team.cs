namespace PDIProject.Domain.Entities
{
    public class Team : BaseClass
    {
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public Team() { }
    }
}
