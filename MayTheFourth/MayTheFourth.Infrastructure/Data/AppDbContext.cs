using MayTheFourth.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<StarShip> StarShip { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Planet> Planet { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var entity = modelBuilder.Entity(entityType.ClrType);
                    entity.Property<long>("Id").HasColumnName($"{entityType.ClrType.Name}Id");
                }
            }
        }
    }
}
