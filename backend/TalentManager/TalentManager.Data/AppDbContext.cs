using Microsoft.EntityFrameworkCore;
using TalentManager.Data.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TalentManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Companies> Companies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("Companies");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(c => c.Name)
                    .HasMaxLength(60)
                    .IsRequired();
            });
        }
    }
}
