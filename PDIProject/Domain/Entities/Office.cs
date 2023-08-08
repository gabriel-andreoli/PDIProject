namespace PDIProject.Domain.Entities
{
    public class Office : BaseClass
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public Office() { }
    }
}
