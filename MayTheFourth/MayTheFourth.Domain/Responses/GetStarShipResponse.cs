using MayTheFourth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Domain.Responses
{
    public class GetStarShipResponse
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string Manufacturer { get; set; }

        public long CostInCredits { get; set; }

        public string Length { get; set; }

        public string MaxSpeed { get; set; }

        public int Crew { get; set; }

        public int Passangers { get; set; }

        public string CargoCapacity { get; set; }

        public double HyperdriveRating { get; set; }

        public double Mglt { get; set; }

        public string Consumables { get; set; }

        public string Class { get; set; }

        public List<dynamic> MoviesIn { get; set; } = [];
    }
}
