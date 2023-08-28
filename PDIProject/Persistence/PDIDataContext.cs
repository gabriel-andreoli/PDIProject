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
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AbilityUser> AbilitiesUsers { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<TaskJob> TaskJobs { get; set; }
        public DbSet<TaskJobUser> TaskJobsUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

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
