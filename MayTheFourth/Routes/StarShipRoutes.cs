using MayTheFourth.Data;
using MayTheFourth.Models;

namespace MayTheFourth.Routes
{
    public static class StarShipRoutes
    {
        public static void MapStarShipRoutes(this WebApplication app)
        {
            app.MapGet("/", (AppDbContext context) => {
                var starships = context.StarShip.ToList();
                return Results.Ok(starships);
            });

            app.MapPost("/", (AppDbContext context, StarShip starship) => {
                context.StarShip.Add(starship);
                context.SaveChanges();
                return Results.Ok(starship);
            });
        }
    }
}
