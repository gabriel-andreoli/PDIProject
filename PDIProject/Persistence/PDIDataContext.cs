using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence
{
    public class PDIDataContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public PDIDataContext(DbContextOptions<PDIDataContext> options) : base(options)
        {
        }
    }
}
