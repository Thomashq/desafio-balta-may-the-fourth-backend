using MayTheFourth.Data;
using MayTheFourth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MayTheFourth.Routes
{
    public static class StarShipRoutes
    {
        public static void MapStarShipRoutes(this WebApplication app)
        {
            app.MapGet("/StarShips/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
            {
                try
                {
                    var totalCount = await context.StarShip.CountAsync();
                    var starships = await context.StarShip
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    return Results.Ok(new
                    {
                        totalCount,
                        skip,
                        take,
                        data = starships
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Get list of all starships").WithOpenApi();

            app.MapGet("/StarShips/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    var starShip = await context.StarShip.FindAsync(id);
                    if (starShip == null)
                        return Results.NotFound($"StarShip with id {id} does not exist");

                    return Results.Ok(new
                    {
                        data = starShip
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Get StarShip by id").WithOpenApi();

            app.MapPost("/StarShips", async (AppDbContext context, StarShip starship) =>
            {
                try
                {
                    await context.StarShip.AddAsync(starship);
                    //Poderia executar enquanto o AddAsync ainda não havia parado de rodar, logo, await auxília a manter a ordem correta
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    {
                        message = "StarShip succesfully created",
                        data = starship
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Create new StarShip").WithOpenApi();

            app.MapPut("/StarShips/{id:long}", async (AppDbContext context, long id, StarShip updatedStarShip) =>
            {
                try
                {
                    StarShip starShipToUpdate = await context.StarShip.FindAsync(id);

                    if (starShipToUpdate == null)
                        return Results.NotFound($"StarShip with id {id} does not exist");

                    foreach (var property in typeof(StarShip).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>(); // Verificar se a propriedade é uma chave primária
                        if (keyAttribute == null) // Sele o keyAttribute for null, nenhuma chave primária está sendo alterada
                        {
                            var updatedValues = property.GetValue(updatedStarShip);
                            if (updatedValues != null)
                            {
                                property.SetValue(starShipToUpdate, updatedValues);
                            }
                        }
                    }
                    context.StarShip.Update(starShipToUpdate);
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    {
                        message = "The StarShip was successfully updated"
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Update StarShip").WithOpenApi();

            app.MapDelete("/StarShips/{id:long}", async(AppDbContext context, long id) =>
            {
                try
                {
                    var starShipToDelete = await context.StarShip.FindAsync(id);

                    if (starShipToDelete == null)
                        return Results.NotFound($"StarShip with id {id} does not exist");

                    context.StarShip.Remove(starShipToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    { 
                        message = "StarShip successfully deleted" 
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Delete StarShip by Id").WithOpenApi();

            app.MapDelete("/StarShips/MultiDelete", async (AppDbContext context, [FromBody] IEnumerable<long> ids) =>
            {
                try
                {
                    var starShipsToDelete = await context.StarShip
                    .Where(s => ids.Contains(s.Id))
                    .ToListAsync();

                    if (starShipsToDelete.Count == 0)
                        return Results.NotFound($"Could not find any StarShips");

                    context.StarShip.RemoveRange(starShipsToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok( new 
                    {
                        message = "List of StarShips successfully deleted" 
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Delete List of StarShips by Id").WithOpenApi();

        }
    }
}
