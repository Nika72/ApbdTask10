using Microsoft.EntityFrameworkCore;
using Tutorial6.Models;

namespace Tutorial6.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}