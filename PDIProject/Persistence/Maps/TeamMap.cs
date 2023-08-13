using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class TeamMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOne(x => x.Department)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.DepartmentId)
                .IsRequired();
        }
    }
}
