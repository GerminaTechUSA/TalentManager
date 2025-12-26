using Microsoft.EntityFrameworkCore;
using TalentManager.Data.Entities;

namespace TalentManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Roles> Roles { get; set; } = null!;

        public DbSet<Softwares> Softwares { get; set; } = null!;

        public DbSet<Modules> Modules { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");

                entity.HasKey(r => r.Id);

                entity.Property(r => r.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(r => r.Name)
                      .HasMaxLength(60)
                      .IsRequired();

                entity.Property(r => r.Notes)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Softwares>(entity =>
            {
                entity.ToTable("Softwares");

                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Name)
                    .HasMaxLength(60)
                    .IsRequired();

            });

            modelBuilder.Entity<Modules>(entity =>
            {
                entity.ToTable("Modules");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(m => m.Name)
                    .HasMaxLength(60)
                    .IsRequired();

                entity.Property(m => m.SoftwareId)
                    .IsRequired();

                entity.Property(m => m.Notes)
                    .IsRequired(false);

                entity.Property(m => m.TargetAudience)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.HasOne(m => m.Software)
                    .WithMany(s => s.Modules)
                    .HasForeignKey(m => m.SoftwareId)
                    .HasConstraintName("FK_Modules_Softwares");

            });
        }
    }
}
