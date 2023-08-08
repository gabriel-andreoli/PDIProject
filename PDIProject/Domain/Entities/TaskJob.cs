﻿namespace PDIProject.Domain.Entities
{
    public class TaskJob : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public ICollection<User> Users { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int RequirementId { get; set; }
        public ICollection<Requirement> Requirements { get; set; }
        public TaskJob() 
        {
            Deleted = false;
            CreatedAt = DateTime.Now;
        }
        
    }
}
