using MayTheFourth.Data;
using MayTheFourth.Infrastructure.Data.Mapping;
using MayTheFourth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourth.Routes;

public static class MovieRoutes
{
    public static void MapMovieRoutes(this WebApplication app)
    {

        app.MapGet("/Movies/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    MappingServices mappingService = new();

                    var movie = await context.Movie.FindAsync(id);

                    if (movie == null)
                        return Results.NotFound($"Movie {id} not found");

                    var characters = await context.Character.ToListAsync();
                    var planets = await context.Planet.ToListAsync();
                    var vehicles = await context.Vehicle.ToListAsync();
                    var starShips = await context.StarShip.ToListAsync();

                    var response = mappingService.MapMovieToResponse(movie, characters, planets, vehicles, starShips);
                    
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }

            }).WithTags("Movies").WithSummary("Get Movie by Id").WithOpenApi();

        app.MapGet("/Movies/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
        {
            try
            {
                MappingServices mappingService = new();

                var totalCount = await context.Movie.CountAsync();

                var movies = await context.Movie
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .ToListAsync();

                if (movies == null || movies.Count == 0)
                {
                    return Results.NotFound("no movies found.");
                }

                var characters = await context.Character.ToListAsync();
                var planets = await context.Planet.ToListAsync();
                var vehicles = await context.Vehicle.ToListAsync();
                var starShips = await context.StarShip.ToListAsync();

                var responses = movies.Select(movie => mappingService.MapMovieToResponse(movie, characters, planets, vehicles, starShips));
              
                return Results.Ok(new
                {
                    totalCount,
                    skip,
                    take,
                    data = responses
                });
            }

            catch (System.Exception ex)
            {
                throw new Exception("The following error has ocurred: " + ex.Message);
            }

        }).WithTags("Movies").WithSummary("Get list Movies").WithOpenApi();

        app.MapPost("/Movies", async (AppDbContext context, [FromBody] Movie movie) =>
        {
            try
            {
                await context.AddAsync(movie);
                await context.SaveChangesAsync();

                return Results.Created($"/Movies/{movie.Id}", movie);
            }
            catch (System.Exception ex)
            {
                throw new Exception("The following error has ocurred: " + ex.Message);
            }


        }).WithTags("Movies").WithSummary("Create Movie").WithOpenApi();

        app.MapPut("/Movies/{id:long}", async (long id, AppDbContext context, [FromBody] Movie movieUpdated) =>
        {
            try
            {
                var movieToUpdate = await context.Movie.FindAsync(id);

                if (movieToUpdate == null)
                    return Results.NotFound("Movie Not found.");

                movieToUpdate.Title = movieUpdated.Title;
                movieToUpdate.Episode = movieUpdated.Episode;
                movieToUpdate.OpeningCrawl = movieUpdated.OpeningCrawl;
                movieToUpdate.Director = movieUpdated.Director;
                movieToUpdate.Producer = movieUpdated.Producer;
                movieToUpdate.ReleaseDate = movieUpdated.ReleaseDate;
                movieToUpdate.Characters = movieUpdated.Characters;
                movieToUpdate.Planets = movieUpdated.Planets;
                movieToUpdate.Vehicles = movieUpdated.Vehicles;
                movieToUpdate.StarShips = movieUpdated.StarShips;

                context.Update(movieToUpdate);

                await context.SaveChangesAsync();

                return Results.Ok("movie updated successfully");
            }
            catch (System.Exception ex)
            {

                throw new Exception("The following error has ocurred: " + ex.Message);
            }
        }).WithTags("Movies").WithSummary("Update Movie").WithOpenApi();

        app.MapDelete("/Movies/{id:long}", async (AppDbContext context, long id) =>
       {
           try
           {
               var movieToDelete = await context.Movie.FindAsync(id);

               if (movieToDelete is null)
                   return Results.NotFound("Movie not found.");

               context.Remove(movieToDelete);

               await context.SaveChangesAsync();

               return Results.Ok("Successfully deleted movie");
           }
           catch (System.Exception ex)
           {
               throw new Exception("The following error has ocurred: " + ex.Message);
           }
       }).WithTags("Movies").WithSummary("Delete Movie by Id").WithOpenApi();

        app.MapDelete("/Movies", async (AppDbContext context, [FromBody] IEnumerable<long> ids) =>
        {
            try
            {
                var moviesToDelete = await context.Movie.Where(s => ids.Contains(s.Id)).ToListAsync();

                if (moviesToDelete.Count == 0)
                    return Results.NotFound("ids do not match movies in database.");

                context.RemoveRange(moviesToDelete);
                await context.SaveChangesAsync();

                return Results.Ok("Successfully deleted movies");
            }
            catch (System.Exception ex)
            {

                throw new Exception("The following error has ocurred: " + ex.Message);
            }
        }).WithTags("Movies").WithSummary("delete a list of films").WithOpenApi();

    }
}
