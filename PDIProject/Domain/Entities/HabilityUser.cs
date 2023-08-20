namespace PDIProject.Domain.Entities
{
    public class HabilityUser : BaseClass
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Hability Hability { get; set; }
        public int HabilityId { get; set; }
        public DateTime DateAcquisition { get; set; }
        public HabilityUser() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
