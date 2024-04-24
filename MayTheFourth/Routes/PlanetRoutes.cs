using MayTheFourth.Data;
using MayTheFourth.Models;
using MayTheFourth.Utility.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace MayTheFourth.Routes;

public static class PlanetRoutes
{
	public static void MapPlanetRoutes(this WebApplication app)
	{
		app.MapGet("/planets/{id:long}", async (AppDbContext context, long id) =>
		{
			var planet = await context.Planet.FindAsync(id);

			if (planet is null)
				return Results.NotFound("Planet could not be found.");

			return Results.Ok(planet);
		}).WithTags("Planets").WithSummary("Get planet by ID.").WithOpenApi();

		app.MapGet("/planets/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
		{
			var totalCount = await context.Planet.CountAsync();

			var planets = await context.Planet
			.AsNoTracking()
			.Skip(skip)
			.Take(take)
			.ToListAsync();

			return Results.Ok(new
			{
				totalCount,
				skip,
				take,
				data = planets
			});

		}).WithTags("Planets").WithSummary("Get all planets.").WithOpenApi();

		app.MapPost("/planets/", async (AppDbContext context, PlanetRequest planetRequest) =>
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

			await context.Planet.AddAsync(planet);

			await context.SaveChangesAsync();

			return Results.Created($"/planets/{planet.Id}", planet.Id);
		}).WithTags("Planets").WithSummary("Add new Planet.").WithOpenApi();

		app.MapPut("/planets/{id:long}", async (AppDbContext context, long id, PlanetRequest planetRequest) =>
		{
			var planetToEdit = await context.Planet.FindAsync(id);

			if (planetToEdit is null)
				return Results.NotFound("Could not find the planet");

			planetToEdit.Update(planetRequest);

			await context.SaveChangesAsync();

			return Results.Ok("Planet edited successfully");
		}).WithTags("Planets").WithSummary("Edit existing Planet.").WithOpenApi();

		app.MapDelete("/planets/", async (AppDbContext context, long id) =>
		{
			var planetToDelete = await context.Planet.FindAsync(id);

			if (planetToDelete is null)
				return Results.NotFound($"Planet with id {id} does not exists");

			context.Planet.Remove(planetToDelete);

			await context.SaveChangesAsync();

			return Results.Ok("Planet successfully deleted");
		}).WithTags("Planets").WithSummary("Delete Planet by ID.").WithOpenApi();

		app.MapDelete("/planets/multiDelete", async (AppDbContext context, [FromBody]IEnumerable<long> ids) =>
		{
			var planetsToDelete = await context.Planet
			.Where(s => ids.Contains(s.Id))
			.ToListAsync();

			if (planetsToDelete.Count == 0)
				return Results.NotFound("Could not find the planets");

			context.Planet.RemoveRange(planetsToDelete);

			await context.SaveChangesAsync();

			return Results.Ok("Successfully deleted list of planets");

		}).WithTags("Planets").WithSummary("Delete Multiple Planets").WithOpenApi();
	}
}
