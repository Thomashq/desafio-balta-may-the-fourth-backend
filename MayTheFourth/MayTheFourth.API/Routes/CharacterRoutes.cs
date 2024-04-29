using MayTheFourth.Data;
using MayTheFourth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MayTheFourth.Routes
{
    public static class CharacterRoutes
    {
        public static void MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/Characters/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
            {
                try
                {
                    var totalCount = await context.Character.CountAsync();

                    if (totalCount == 0)
                        return Results.NotFound("No Characters found");

                    var characters = await context.Character
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    return Results.Ok(new 
                    { 
                        totalCount,
                        skip,
                        take,
                        data = characters
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Get all characters.").WithOpenApi();

            app.MapGet("/Characters/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    var character = await context.Character.FindAsync(id);

                    if (character == null)
                    {
                        Results.NotFound($"Character with id {id} does not exist");
                    }

                    return Results.Ok(character);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Get character by ID.").WithOpenApi();

            app.MapPost("/Characters", async (AppDbContext context, Character character) =>
            {
                try
                {
                    await context.Character.AddAsync(character);

                    await context.SaveChangesAsync();

                    return Results.Created(string.Empty, character);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
                
            }).WithTags("Characters").WithSummary("Create a character.").WithOpenApi();

            app.MapPut("/Characters/{id:long}", async (AppDbContext context, long id, Character updatedCharacter) =>
            {
                try
                {
                    Character characterToUpdate = await context.Character.FindAsync(id);

                    if (characterToUpdate is null)
                    {
                        return Results.NotFound($"Character with id {id} does not exist");
                    }

                    foreach (var property in typeof(Character).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                        if (keyAttribute is not null)
                            continue;

                        var updatedValues = property.GetValue(updatedCharacter);
                        if (updatedValues is null) 
                            continue;

                        property.SetValue(characterToUpdate, updatedValues);
                    }

                    context.Character.Update(characterToUpdate);
                   
                    await context.SaveChangesAsync();
                    return Results.Ok($"Character with id {id} was successfully updated");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Edit a character by ID.").WithOpenApi();

            app.MapDelete("/Characters/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    var character = await context.Character.FindAsync(id);

                    if (character is null)
                    {
                        return Results.NotFound();
                    }

                    context.Character.Remove(character);

                    await context.SaveChangesAsync();

                    return Results.Ok("Character succesfully deleted");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Delete a character by ID.").WithOpenApi();

            app.MapDelete("/Characters", async (AppDbContext context, [FromBody] IEnumerable<long> ids) =>
            {
                try
                {
                    var charactersToDelete = await context.Character
                    .Where(s => ids.Contains(s.Id))
                    .ToListAsync();

                    if (charactersToDelete.Count == 0)
                        return Results.NotFound("The given ids dont correspond to the Characters in database");
                    
                    context.Character.RemoveRange(charactersToDelete);

                    await context.SaveChangesAsync();

                    return Results.Ok("List of Characters succesfully deleted");
                } 
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Delete a List of Characters").WithOpenApi();
        }
    }
}
