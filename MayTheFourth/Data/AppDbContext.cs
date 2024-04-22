using MayTheFourth.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<StarShip> StarShip { get; set; }
        public DbSet<Character> Character { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BaseModel.Configure(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
