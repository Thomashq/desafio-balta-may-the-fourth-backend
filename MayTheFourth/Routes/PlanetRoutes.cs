using MayTheFourth.Data;
using MayTheFourth.Models;
using MayTheFourth.Utility.Requests;

namespace MayTheFourth.Routes;

public static class PlanetRoutes
{
	public static void MapPlanetRoutes(this WebApplication app)
	{
		app.MapGet("/planets/{id}", (AppDbContext context, long id) =>
		{
			var planet = context.Planet.Find(id);

			if (planet is null)
				return Results.NotFound("Planet could not be found.");

			return Results.Ok(planet);
		}).WithTags("Planets").WithSummary("Get planet by ID.").WithOpenApi();


		app.MapGet("/planets/", (AppDbContext context) =>
		{
			var planets = context.Planet.ToList();
			return Results.Ok(planets);
		}).WithTags("Planets").WithSummary("Get all planets.").WithOpenApi();

		app.MapPost("/planets/", (AppDbContext context, PlanetRequest planetRequest) =>
		{
			var planet = new Planet
			{
				Name = planetRequest.Name,
				Movies = planetRequest.Movies,
				Characters = planetRequest.Characters,
				Population = planetRequest.Population,
				Climate	= planetRequest.Climate,
				Diameter = planetRequest.Diameter,
				Gravity = planetRequest.Gravity,
				OrbitalPeriod = planetRequest.OrbitalPeriod,
				RotationPeriod = planetRequest.RotationPeriod,
				SurfaceWater = planetRequest.SurfaceWater,
				Terrain = planetRequest.Terrain
			};

			context.Planet.Add(planet);
			context.SaveChanges();
			return Results.Created($"/planets/{planet.Id}", planet.Id);
		}).WithTags("Planets").WithSummary("Add new Planet.").WithOpenApi();

		app.MapPut("/planets/{id}", (AppDbContext context, long id, PlanetRequest planetRequest) =>
		{
			var planetToEdit = context.Planet.Find(id);

			if (planetToEdit is null)
				return Results.NotFound("Could not find the planet");

			planetToEdit.Update(planetRequest);

			context.SaveChanges();

			return Results.Ok("Planet edited successfully");
		}).WithTags("Planets").WithSummary("Edit existing Planet.").WithOpenApi();

		app.MapDelete("/planets/", (AppDbContext context, long id) =>
		{
			var planetToDelete = context.Planet.Find(id);

			if (planetToDelete is null)
				return Results.NotFound($"Planet with id {id} does not exists");

			context.Planet.Remove(planetToDelete);
			context.SaveChanges();
			return Results.Ok("Planet successfully deleted");
		}).WithTags("Planets").WithSummary("Delete Planet by ID.").WithOpenApi();
	}
}
