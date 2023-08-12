using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class UserMap
    {
        public static void Map(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(x => x.Office)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.OfficeId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.Habilities)
                .WithMany(x => x.Users);

            modelBuilder.Entity<User>()
                .HasMany(x => x.TaskJobs)
                .WithMany(x => x.Users);
        }
    }
}
