using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class CompanyMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasOne(company => company.Address) 
                .WithOne() 
                .HasForeignKey<Company>(company => company.AddressId)
                .IsRequired(); 
        }
    }
}
