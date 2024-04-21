namespace MayTheFourth.Routes
{
    public static class StarShipRoutes
    {
        public static void MapStarShipRoutes(this WebApplication app)
        {
            app.MapGet("/", () => "Hello World");
        }
    }
}
