﻿using MayTheFourth.Data;
using MayTheFourth.Domain.Responses;
using MayTheFourth.Infrastructure.Data.Mapping;
using MayTheFourth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MayTheFourth.Routes;

public static class PlanetRoutes
{
	public static void MapPlanetRoutes(this WebApplication app)
	{
		app.MapGet("/Planets/{id:long}", async (AppDbContext context, long id) =>
		{
			try
			{
				MappingServices mappingServices = new();
				var planet = await context.Planet.FindAsync(id);

				if (planet is null)
					return Results.NotFound("Planet could not be found.");
				
				var characters = await context.Character.ToListAsync();
				var movies = await context.Movie.ToListAsync();

				var response = mappingServices.MapPlanetToResponse(planet, characters, movies);

				return Results.Ok(response);
			}
			catch(Exception ex)
			{
                throw new Exception("The following error has occurred: " + ex.Message);
            }
		}).WithTags("Planets").WithSummary("Get planet by ID.").WithOpenApi();


		app.MapGet("/Planets/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
		{
			try
			{
                MappingServices mappingServices = new();

                var totalCount = await context.Planet.CountAsync();

				if(totalCount == 0)
					return Results.NotFound("No Planets found");

				var planets = await context.Planet
				.AsNoTracking()
				.Skip(skip)
				.Take(take)
				.ToListAsync();

                var characters = await context.Character.ToListAsync();
                var movies = await context.Movie.ToListAsync();

				var responses = planets.Select(planet => mappingServices.MapPlanetToResponse(planet, characters, movies));
                return Results.Ok(new
				{
					totalCount,
					skip,
					take,
					data = responses
				});
			}
			catch(Exception ex)
			{
				throw new Exception("The following error has occurred: " + ex.Message);
			}
		}).WithTags("Planets").WithSummary("Get all planets.").WithOpenApi();

		app.MapPost("/Planets", async (AppDbContext context,  Planet planet) =>
		{
			try
			{
				await context.Planet.AddAsync(planet);

				await context.SaveChangesAsync();

				return Results.Created($"/planets/{planet.Id}", planet.Id);
			}
			catch(Exception ex)
			{
                throw new Exception("The following error has occurred: " + ex.Message);
            }
		}).WithTags("Planets").WithSummary("Add new Planet.").WithOpenApi();

		app.MapPut("/Planets/{id:long}", async (AppDbContext context, long id, Planet updatedPlanet) =>
		{
			try
			{
				var planet = await context.Planet.FindAsync(id);

				if (planet is null)
					return Results.NotFound("Could not find the planet");

				foreach (var property in typeof(Planet).GetProperties())
				{
					if (property.GetCustomAttribute<KeyAttribute>() is not null)
						continue;

					var value = property.GetValue(updatedPlanet);
					if (value is null)
						continue;

					property.SetValue(planet, value);
				}

				context.Planet.Update(planet);

				await context.SaveChangesAsync();

				return Results.Ok("Planet edited successfully");
			}
			catch(Exception ex)
			{
                throw new Exception("The following error has occurred: " + ex.Message);
            }
		}).WithTags("Planets").WithSummary("Edit existing Planet.").WithOpenApi();

		app.MapDelete("/Planets/{id:long}", async (AppDbContext context, long id) =>
		{
			try
			{
				var planetToDelete = await context.Planet.FindAsync(id);

				if (planetToDelete is null)
					return Results.NotFound($"Planet with id {id} does not exists");

				context.Planet.Remove(planetToDelete);
				
				await context.SaveChangesAsync();

				return Results.Ok("Planet successfully deleted");
			}
			catch (Exception ex)
			{
                throw new Exception("The following error has occurred: " + ex.Message);
            }
		}).WithTags("Planets").WithSummary("Delete Planet by ID.").WithOpenApi();

		app.MapDelete("/Planets", async (AppDbContext context, [FromBody]IEnumerable<long> ids) =>
		{
			try
			{
				var planetsToDelete = await context.Planet
				.Where(s => ids.Contains(s.Id))
				.ToListAsync();

				if (planetsToDelete.Count == 0)
					return Results.NotFound("The given ids dont correspond to the Planets in database");

				context.Planet.RemoveRange(planetsToDelete);

				await context.SaveChangesAsync();

				return Results.Ok("List of Planets succesfully deleted");
			}
			catch(Exception ex)
			{
                throw new Exception("The following error has occurred: " + ex.Message);
            }
		}).WithTags("Planets").WithSummary("Delete List of planets by id").WithOpenApi();
	}
}
