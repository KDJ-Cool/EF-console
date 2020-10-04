using Microsoft.EntityFrameworkCore;
using Royal.Domain;

namespace Royal.Data
{
    public class RoyalContext : DbContext
    {
        public DbSet<Knight> Knights { get; set; }
        public DbSet<KnightVows> Vows { get; set; }
        public DbSet<RoyalFamily> Families { get; set; }
        public DbSet<Castle> Castles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RoyalDb;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnightVows>().HasKey(v => new {v.KnightId, v.VowId});
        }
    }
}
