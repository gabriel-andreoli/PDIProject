using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class UserMap
    {
        public static void Map(ModelBuilder modelBuilder) 
        {
            //1-N
            modelBuilder.Entity<User>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(x => x.Team)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.TeamId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasOne(x => x.JobPosition)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.JobPositionId)
                .IsRequired();

            //N-N
            modelBuilder.Entity<User>()
                .HasMany(x => x.HabilitiesUser)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.TaskJobUsers)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
        }
    }
}
