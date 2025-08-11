using Microsoft.EntityFrameworkCore;
using API.Models; 

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<DamageResult> DamageResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DamageResult>()
                .Property(p => p.bbox)
                .HasColumnType("double precision[]");
        }
    }
}
