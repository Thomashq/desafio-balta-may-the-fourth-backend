using MayTheFourth.Data;
using MayTheFourth.Infrastructure.Data.Mapping;
using MayTheFourth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MayTheFourth.Routes
{
    public static class VehicleRoutes
    {
        public static void MapVehicleRoutes(this WebApplication app)
        {
            app.MapGet("/Vehicles/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    MappingServices mappingServices = new();

                    var vehicle = await context.Vehicle.FindAsync(id);

                    if (vehicle == null)
                        return Results.NotFound($"Vehicle with id {id} does not exist");

                    var movies = await context.Movie.ToListAsync();

                    var response = mappingServices.MapVehicleToResponse(vehicle, movies);

                    return Results.Ok(new
                    {
                        data = response
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("Vehicles").WithSummary("Get Vehicle by id").WithOpenApi();

            app.MapGet("/Vehicles/{skip:int}/{take:int}", async (AppDbContext context, int skip, int take) =>
            {
                try
                {
                    MappingServices mappingServices = new();

                    var totalCount = await context.Vehicle.CountAsync();

                    if (totalCount == 0)
                        return Results.NotFound("No vehicles found");

                    var vehicles = await context.Vehicle
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    var movies = await context.Movie.ToListAsync();

                    var responses = vehicles.Select(vehicle => mappingServices.MapVehicleToResponse(vehicle, movies));

                    return Results.Ok(new
                    {
                        totalCount,
                        skip,
                        take,
                        data = responses
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("Vehicles").WithSummary("Get list of all vehicles").WithOpenApi();

            app.MapPost("/Vehicles/", async (AppDbContext context, Vehicle vehicle) =>
            {
                await context.Vehicle.AddAsync(vehicle);
                await context.SaveChangesAsync();

                return Results.Ok(new
                {
                    message = "Vehicle succesfully created",
                    data = vehicle
                });
            }).WithTags("Vehicles").WithSummary("Create new vehicle").WithOpenApi();

            app.MapPut("/Vehicles/{id:long}", async (AppDbContext context, long id, Vehicle updatedVehicle) =>
            {
                try
                {
                    Vehicle vehicleToUpdate = await context.Vehicle.FindAsync(id);

                    if (vehicleToUpdate == null)
                        return Results.NotFound($"Vehicle with id {id} does not exist");

                    foreach (var property in typeof(Vehicle).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>();

                        if (keyAttribute == null)
                        {
                            var updatedValues = property.GetValue(updatedVehicle);
                            if (updatedValues != null)
                            {
                                property.SetValue(vehicleToUpdate, updatedValues);
                            }
                        }
                    }
                    context.Vehicle.Update(vehicleToUpdate);
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    {
                        message = "The vehicle was successfully updated"
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("Vehicles").WithSummary("Update Vehicle").WithOpenApi();

            app.MapDelete("/Vehicles/{id:long}", async (AppDbContext context, long id) =>
            {
                try
                {
                    var VehicleToDelete = await context.Vehicle.FindAsync(id);

                    if (VehicleToDelete == null)
                        return Results.NotFound($"Vehicle with id {id} does not exist");

                    context.Vehicle.Remove(VehicleToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    {
                        message = "Vehicle successfully deleted"
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("Vehicles").WithSummary("Delete vehicle by Id").WithOpenApi();

            app.MapDelete("/Vehicles", async (AppDbContext context, [FromBody] IEnumerable<long> ids) =>
            {
                try
                {
                    var VehiclesToDelete = await context.Vehicle.Where(s => ids.Contains(s.Id)).ToListAsync();

                    if (VehiclesToDelete.Count == 0)
                        return Results.NotFound("Could not find any Vehicles");

                    context.Vehicle.RemoveRange(VehiclesToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok(new
                    {
                        message = "List of Vehicles successfully deleted"
                    });
                }
                catch (Exception ex)
                {
                    throw new Exception("The following error has ocurred: " + ex.Message);
                }
            }).WithTags("Vehicles").WithSummary("Delete List of Vehicles by Id").WithOpenApi();
        }
    }
}
