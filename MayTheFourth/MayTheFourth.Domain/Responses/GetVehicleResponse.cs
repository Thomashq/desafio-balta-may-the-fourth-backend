using MayTheFourth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Domain.Responses
{
    public class GetVehicleResponse
    {
        public string CargoCapacity { get; set; }

        public int Passangers { get; set; }

        public int Crew { get; set; }

        public string MaxSpeed { get; set; }

        public string Length { get; set; }

        public double CostInCredits { get; set; }

        public string Manufacturer { get; set; }

        public int Model { get; set; }

        public string Name { get; set; }

        public string Consumables { get; set; }

        public List<dynamic> Movies { get; set; } = [];
    }
}
