using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HasarTespiti.Domain.Entities;

namespace HasarTespiti.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Photo> Photos => Set<Photo>();
        public DbSet<AppUser> AppUsers => Set<AppUser>();

        public DbSet<Prediction> Predictions => Set<Prediction>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<Photo>()
                .HasMany(p => p.Predictions)
                .WithOne(x => x.Photo)
                .HasForeignKey(x => x.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
