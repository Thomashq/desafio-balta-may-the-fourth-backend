using MayTheFourth.Data;
using MayTheFourth.Models;

namespace MayTheFourth.Routes
{
    public static class CharacterRoutes
    {
        public static void MapCharacterRoutes(this WebApplication app)
        {
            app.MapGet("/characters/{id}", (AppDbContext context, long id) =>
            {
                var character = context.Character.Find(id);
                return character == null ? Results.NotFound() : Results.Ok(character);
            });

            app.MapGet("/characters", (AppDbContext context) =>
            {
                var characters = context.Character.ToList();
                return Results.Ok(characters);
            });

            app.MapPost("/characters", (AppDbContext context, Character character) =>
            {
                context.Character.Add(character);
                context.SaveChanges();
                return Results.Created(string.Empty, character);
            });

            app.MapPut("/characters/{id}", (AppDbContext context, long id, Character character) =>
            {
                var existingCharacter = context.Character.Find(id);
                if (existingCharacter is null)
                {
                    return Results.NotFound();
                }
                existingCharacter.Name = character.Name;
                existingCharacter.Height = character.Height;
                existingCharacter.Weight = character.Weight;
                existingCharacter.HairColor = character.HairColor;
                existingCharacter.SkinColor = character.SkinColor;
                existingCharacter.EyeColor = character.EyeColor;
                existingCharacter.BirthYear = character.BirthYear;
                existingCharacter.Gender = character.Gender;

                context.Character.Update(existingCharacter);
                context.SaveChanges();
                return Results.Ok(existingCharacter);
            });

            app.MapDelete("/characters/{id}", (AppDbContext context, long id) =>
            {
                var character = context.Character.Find(id);
                if (character is null)
                {
                    return Results.NotFound();
                }
                context.Character.Remove(character);
                context.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
