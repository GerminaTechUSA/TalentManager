using Microsoft.EntityFrameworkCore;
using TalentManager.Data.Entities;
using System.Collections.Generic;

namespace TalentManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        // Manteve os dois DbSets
        public DbSet<Companies> Companies { get; set; } = null!;
        public DbSet<Roles> Roles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de Companies (Sua)
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

            // Configuração de Roles (Do colega)
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");

                entity.HasKey(r => r.Id);

                entity.Property(c => c.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(c => c.Name)
                      .HasMaxLength(60)
                      .IsRequired();

                entity.Property(c => c.Notes)
                      .IsRequired(false);
            });
        }
    }
}