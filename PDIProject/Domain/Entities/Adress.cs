namespace PDIProject.Domain.Entities
{
    public class Adress : BaseClass
    {
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public Adress() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
