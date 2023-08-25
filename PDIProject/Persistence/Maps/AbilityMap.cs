using Microsoft.EntityFrameworkCore;
using PDIProject.Domain.Entities;

namespace PDIProject.Persistence.Maps
{
    public static class AbilityMap
    {
        public static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>()
                .HasMany(x => x.AbilitiesUsers)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId)
                .IsRequired();

            modelBuilder.Entity<Ability>()
                .HasMany(x => x.Requirements)
                .WithOne(x => x.Ability)
                .HasForeignKey(x => x.AbilityId)
                .IsRequired();
        }
    }
}
