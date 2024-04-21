using MayTheFourth.Models;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<StarShip> StarShips{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            BaseModel.Configure(builder);        }
    }
}
