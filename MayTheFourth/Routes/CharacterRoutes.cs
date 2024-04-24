using MayTheFourth.Data;
using MayTheFourth.Models;

namespace MayTheFourth.Routes
{
    public static class CharacterRoutes
    {
        public static void MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/characters", (AppDbContext context) =>
            {
                try
                {
                    var characters = context.Character.ToList();
                    return Results.Ok(characters);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Get all characters.").WithOpenApi();

            app.MapGet("/characters/{id}", (AppDbContext context, long id) =>
            {
                try
                {
                    var character = context.Character.Find(id);
                    if (character == null)
                    {
                        Results.NotFound($"Character with id {id} does not exist");
                    }
                    Results.Ok(character);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Get character by ID.").WithOpenApi();

            app.MapPost("/characters", (AppDbContext context, Character character) =>
            {
                try
                {
                    context.Character.Add(character);
                    context.SaveChanges();
                    return Results.Created(string.Empty, character);
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
                
            }).WithTags("Characters").WithSummary("Create a character.").WithOpenApi();

            app.MapPut("/characters/{id}", (AppDbContext context, long id, Character updatedCharacter) =>
            {
                try
                {
                    Character characterToUpdate = context.Character.Find(id);

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
                    context.SaveChanges();
                    return Results.Ok($"Character with id {id} was successfully updated");
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Edit a character by ID.").WithOpenApi();

            app.MapDelete("/characters/{id}", (AppDbContext context, long id) =>
            {
                try
                {
                    var character = context.Character.Find(id);
                    if (character is null)
                    {
                        return Results.NotFound();
                    }
                    context.Character.Remove(character);
                    context.SaveChanges();
                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has occurred: " + ex.Message);
                }
            }).WithTags("Characters").WithSummary("Delete a character by ID.").WithOpenApi();
        }
    }
}
