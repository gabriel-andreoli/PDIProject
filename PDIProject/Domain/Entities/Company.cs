namespace PDIProject.Domain.Entities
{
    public class Company : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int TotalEmployees { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public Company()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }

        public void Update(string name, string email, string phone, int totalEmployees)
        {
            Name = name;
            Email = email;
            Phone = phone;
            TotalEmployees = totalEmployees;
            UpdateMe();
        }
    }
}
