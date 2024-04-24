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
            app.MapGet("/StarShips", (AppDbContext context) =>
            {
                try
                {
                    var starships = context.StarShip.ToList();
                    return Results.Ok(starships);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Get list of all starships").WithOpenApi();

            app.MapGet("/StarShips/{id}", (AppDbContext context, long id) =>
            {
                try
                {
                    var starShip = context.StarShip.Find(id);
                    if (starShip == null)
                        return Results.NotFound($"StarShip with id {id} does not exist");

                    return Results.Ok(starShip);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Get StarShip by id").WithOpenApi();

            app.MapPost("/StarShips", (AppDbContext context, StarShip starship) =>
            {
                try
                {
                    context.StarShip.Add(starship);
                    context.SaveChanges();

                    return Results.Ok(starship);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Create new StarShip").WithOpenApi();

            app.MapPut("/StarShips/{id}", (AppDbContext context, long id, StarShip updatedStarShip) =>
            {
                try
                {
                    StarShip starShipToUpdate = context.StarShip.Find(id);

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
                    context.SaveChanges();

                    return Results.Ok("The StarShip was successfully updated");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Update StarShip").WithOpenApi();

            app.MapDelete("/StarShips/{id}", (AppDbContext context, long id) =>
            {
                try
                {
                    var starShipToDelete = context.StarShip.Find(id);

                    if (starShipToDelete == null)
                        return Results.NotFound($"StarShip with id {id} does not exist");

                    context.StarShip.Remove(starShipToDelete);
                    context.SaveChanges();

                    return Results.Ok("StarShip successfully deleted");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Delete StarShip by Id").WithOpenApi();

            app.MapDelete("/StarShips/MultiDelete", (AppDbContext context, [FromBody] IEnumerable<long> ids) =>
            {
                try
                {
                    var starShipsToDelete = context.StarShip
                    .Where(s => ids.Contains(s.Id))
                    .ToList();

                    if (starShipsToDelete.Count == 0)
                        return Results.NotFound($"Could not find any StarShips");

                    context.StarShip.RemoveRange(starShipsToDelete);
                    context.SaveChanges();

                    return Results.Ok("List of StarShips successfully deleted");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("StarShips").WithSummary("Delete List of StarShips by Id").WithOpenApi();

        }
    }
}
