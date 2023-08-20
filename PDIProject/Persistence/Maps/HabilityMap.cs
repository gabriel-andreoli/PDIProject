using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class HabilityMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hability>()
                .HasMany(x => x.HabilitiesUser)
                .WithOne(x => x.Hability)
                .HasForeignKey(x => x.HabilityId)
                .IsRequired();
        }
    }
}
