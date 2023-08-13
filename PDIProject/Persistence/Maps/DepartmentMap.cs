using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class DepartmentMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Departments)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();
        }
    }
}
