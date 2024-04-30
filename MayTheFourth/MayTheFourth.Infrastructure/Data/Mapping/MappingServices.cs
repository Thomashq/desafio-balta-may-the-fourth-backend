using MayTheFourth.Domain.Responses;
using MayTheFourth.Models;
using MayTheFourth.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Infrastructure.Data.Mapping
{
    public class MappingServices
    {
        public GetCharacterReponses MapCharacterToResponse(Character character, IEnumerable<Movie> movies, IEnumerable<Planet> planets)
        {
            return new GetCharacterReponses
            {
                Name = character.Name,
                Height = character.Height,
                Weight = character.Weight,
                HairColor = character.HairColor,
                SkinColor = character.SkinColor,
                EyeColor = character.EyeColor,
                BirthYear = character.BirthYear,
                Gender = character.Gender,
                Planets = planets
                    .Where(planet => character.Planet.Contains(planet.Id))
                    .Select(planet => new { Id = planet.Id, Name = planet.Name,})
                    .ToList<object>(),
                Movies = movies
                    .Where(movie => character.Movies.Contains(movie.Id))
                    .Select(movie => new { Id = movie.Id, Title = movie.Title })
                    .ToList<object>()
            };
        }

        public GetMovieResponse MapMovieToResponse(Movie movie, IEnumerable<Character> characters, IEnumerable<Planet> planets, IEnumerable<Vehicle> vehicles, IEnumerable<StarShip> starships)
        {
            return new GetMovieResponse
            {
                Title = movie.Title,
                Episode = movie.Episode,
                OpeningCrawl = movie.OpeningCrawl,
                Director = movie.Director,
                Producer = movie.Producer,
                ReleaseDate = movie.ReleaseDate,
                Characters = characters
                    .Where(character => movie.Characters.Contains(character.Id))
                    .Select(character => new { Id = character.Id, Name = character.Name })
                    .ToList<object>(),
                Planets = planets
                    .Where(planet => movie.Planets.Contains(planet.Id))
                    .Select(planet => new { Id = planet.Id, Name = planet.Name })
                    .ToList<object>(),
                Vehicles = vehicles
                    .Where(vehicle => movie.Vehicles.Contains(vehicle.Id))
                    .Select(vehicle => new { Id = vehicle.Id, Name = vehicle.Name })
                    .ToList<object>(),
                StarShips = starships
                    .Where(starship => movie.StarShips.Contains(starship.Id))
                    .Select(starship => new { Id = starship.Id, Name = starship.Name })
                    .ToList<object>()
            };
        }

        public GetStarShipResponse MapStarShipToResponse(StarShip starShip, IEnumerable<Movie> movies)
        {
            return new GetStarShipResponse
            {
                Name = starShip.Name,
                Model = starShip.Model,
                Manufacturer = starShip.Manufacturer,
                CostInCredits = starShip.CostInCredits,
                Length = starShip.Length,
                MaxSpeed = starShip.MaxSpeed,
                Crew = starShip.Crew,
                Passangers = starShip.Passangers,
                CargoCapacity = starShip.CargoCapacity,
                HyperdriveRating = starShip.HyperdriveRating,
                Mglt = starShip.Mglt,
                Consumables = starShip.Consumables,
                Class = starShip.Class,
                MoviesIn = movies
                    .Where(movie => starShip.Movies.Contains(movie.Id))
                    .Select(movie => new { Id = movie.Id, Title = movie.Title })
                    .ToList<object>()
            };
        }

        public GetPlanetResponse MapPlanetToResponse(Planet planet, IEnumerable<Character> characters, IEnumerable<Movie> movies)
        {
            return new GetPlanetResponse
            {
                Name = planet.Name,
                RotationPeriod = planet.RotationPeriod,
                OrbitalPeriod = planet.OrbitalPeriod,
                Diameter = planet.Diameter,
                Climate = planet.Climate,
                Gravity = planet.Gravity,
                Terrain = planet.Terrain,
                SurfaceWater = planet.SurfaceWater,
                Population = planet.Population,
                Characters = characters
                    .Where(character => planet.Characters.Contains(character.Id))
                    .Select(character => new { Id = character.Id, Name = character.Name })
                    .ToList<object>()
            };
        }

        public GetVehicleResponse MapVehicleToResponse(Vehicle vehicle, IEnumerable<Movie> movies)
        {
            return new GetVehicleResponse
            {
                CargoCapacity = vehicle.CargoCapacity,
                Passangers = vehicle.Passangers,
                Crew = vehicle.Crew,
                MaxSpeed = vehicle.MaxSpeed,
                Length = vehicle.Length,
                CostInCredits = vehicle.CostInCredits,
                Manufacturer = vehicle.Manufacturer,
                Model = vehicle.Model,
                Name = vehicle.Name,
                Consumables = vehicle.Consumables,
                Movies = movies
                    .Where(movie => vehicle.Movies.Contains(movie.Id))
                    .Select(movie => new { Id = movie.Id, Title = movie.Title })
                    .ToList<object>()
            };
        }
    }
}
