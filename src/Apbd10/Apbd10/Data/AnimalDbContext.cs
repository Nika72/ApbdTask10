using Microsoft.EntityFrameworkCore;
using Tutorial6.Models;

namespace Tutorial6.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animals");  

                entity.HasKey(e => e.Id);   

                entity.Property(e => e.Id)   
                    .HasColumnName("IdAnimal");  

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(200);
                entity.Property(e => e.Category).HasMaxLength(200);
                entity.Property(e => e.Area).HasMaxLength(200);
            });
        }
    }
}