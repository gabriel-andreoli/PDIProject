namespace PDIProject.Domain.Entities
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public void UpdateMe()
        {
            UpdatedAt = DateTime.Now;
        }

        public void DeleteMe()
        {
            Deleted = true;
            UpdateMe();
        }
    }
}
