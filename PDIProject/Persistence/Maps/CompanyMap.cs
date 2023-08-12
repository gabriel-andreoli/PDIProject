using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class CompanyMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Company);

            modelBuilder.Entity<Company>()
                .HasOne(x => x.Adress)
                .WithOne(x => x.Company);
        }
    }
}
