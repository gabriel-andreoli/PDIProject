using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;
using PDIProject.Persistence.Maps;
using System.Reflection.Metadata;

namespace PDIProject.Persistence
{
    public class PDIDataContext : DbContext
    {
        public PDIDataContext(DbContextOptions<PDIDataContext> options) : base(options) {}
        public DbSet<Address> adresses { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Ability> abilities { get; set; }
        public DbSet<AbilityUser> abilitiesusers { get; set; }
        public DbSet<JobPosition> jobpositions { get; set; }
        public DbSet<Requirement> requirements { get; set; }
        public DbSet<TaskJob> taskjobs { get; set; }
        public DbSet<TaskJobUser> taskjobsusers { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            UserMap.Map(modelBuilder);
            CompanyMap.Map(modelBuilder);
            AbilityMap.Map(modelBuilder);
            TaskJobMap.Map(modelBuilder);
            DepartmentMap.Map(modelBuilder);
            TeamMap.Map(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
