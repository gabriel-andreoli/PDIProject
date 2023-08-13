using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class TaskJobMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            //1-n
            modelBuilder.Entity<TaskJob>()
                .HasOne(x => x.Company)
                .WithMany(x => x.TaskJobs)
                .HasForeignKey(x => x.CompanyId)
                .IsRequired();

            //N-N
            modelBuilder.Entity<TaskJob>()
                .HasMany(x => x.Requirements)
                .WithMany(x => x.TaskJobs);
        }
    }
}
