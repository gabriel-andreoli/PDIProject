namespace PDIProject.Domain.Entities
{
    public class Ability : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public ICollection<AbilityUser> AbilitiesUsers { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public Ability() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            AbilitiesUsers = new List<AbilityUser>();
            Requirements = new List<Requirement>();
        }
    }
}
