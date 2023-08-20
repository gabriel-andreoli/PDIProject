namespace PDIProject.Domain.Entities
{
    public class Hability : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public ICollection<HabilityUser> HabilitiesUser { get; set; }
        public Hability() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
            HabilitiesUser = new List<HabilityUser>();
        }
    }
}
