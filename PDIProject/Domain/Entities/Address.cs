namespace PDIProject.Domain.Entities
{
    public class Address : BaseClass
    {
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public Address() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
