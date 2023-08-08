using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence
{
    public class PDIDataContext : DbContext
    {
        public PDIDataContext(DbContextOptions<PDIDataContext> options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Hability> Habilities { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<TaskJob> Tasks { get; set; }
    }
}
