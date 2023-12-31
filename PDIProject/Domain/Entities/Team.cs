﻿namespace PDIProject.Domain.Entities
{
    public class Team : BaseClass
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<User> Users { get; set; }
        public Team() 
        { 
            Deleted = false;
            CreatedAt = DateTime.Now;
            Users = new List<User>();
        }
    }
}
