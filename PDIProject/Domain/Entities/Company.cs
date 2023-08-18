namespace PDIProject.Domain.Entities
{
    public class Company : BaseClass
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int TotalEmployees { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<TaskJob> TaskJobs { get; set; }
        public ICollection<Department> Departments { get; set; }
        public Company()
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            Users = new List<User>();
            TaskJobs = new List<TaskJob>();
            Departments = new List<Department>();
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
