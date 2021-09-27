using Microsoft.EntityFrameworkCore;
using mlwinum.PetShop.Infrastructure.Data.Entities;

namespace mlwinum.PetShop.Infrastructure.Data
{
    public class PetApplicationContext : DbContext
    {
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }

        public PetApplicationContext(DbContextOptions<PetApplicationContext> options) : base(options)
        {
            
        }
    }
}