namespace PDIProject.Domain.Entities
{
    public class Company : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? PostalCode { get; set; }
        public int TotalEmployees { get; set; }
        public List<User> Users { get; set; }
        public Company()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }

        public void Update(string name, string email, string street, string neighborhood, string city, string state,
            string country, string phone, string postalCode, int totalEmployees)
        {
            Name = name;
            Email = email;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            Phone = phone;
            PostalCode = postalCode;
            TotalEmployees = totalEmployees;
            UpdateMe();
        }
    }
}
