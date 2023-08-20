namespace PDIProject.Domain.Entities
{
    public class AbilityUser : BaseClass
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Ability Ability { get; set; }
        public int AbilityId { get; set; }
        public DateTime DateAcquisition { get; set; }
        public AbilityUser() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
    }
}
