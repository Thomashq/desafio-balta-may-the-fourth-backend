using MayTheFourth.Models;
using MayTheFourth.Domain.Responses;
using System.Collections.Generic;
using System.Linq;
using MayTheFourth.Data;

namespace MayTheFourth.Infrastructure.Data.Mapping
{
    public class StarShipMappingService
    {
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
                    .Where(movie => starShip.MoviesIn.Contains(movie.Id))
                    .Select(movie => new { movie.Id, movie.Title })
                    .ToList<object>()
            };
        }
    }
}
