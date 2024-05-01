using MayTheFourth.Data;
using MayTheFourth.Domain.Responses;
using MayTheFourth.Models;
using MayTheFourth.Tests.IntegrationTests.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace MayTheFourth.Tests.IntegrationTests;

[Collection("Sequential")]
public class PlanetEndpointsTests : IClassFixture<TestWebApplicationFactory<Program>>
{
    private readonly TestWebApplicationFactory<Program> _factory;
    private readonly HttpClient _httpClient;

    public PlanetEndpointsTests(TestWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task GetPlanetsWithPaginationEndpoint_WhenHasPlanets_ReturnListOfPlanets()
    {
        using (var scope = _factory.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<AppDbContext>();
            
            var moqPlanet = new Planet()
            {
                Name = "Test",
                RotationPeriod = "Test",
                OrbitalPeriod = "Test",
                Diameter = "Test",
                Climate = "Test",
                Gravity = "Test",
                Terrain = "Test",
                SurfaceWater = "Test",
                Population = "Test",
                Characters = new List<long>(),
                Movies = new List<long>(),
            };
            db.Planet.Add(moqPlanet);
            db.SaveChanges();
        }

        var response = await _httpClient.GetFromJsonAsync<GetPlanetWithPaginationResponse>("/Planets/0/3");

        Assert.NotNull(response);
    }

}
