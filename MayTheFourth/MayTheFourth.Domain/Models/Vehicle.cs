using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Vehicle : BaseModel
    {
        [Column("cargoCapacity")]
        public string CargoCapacity { get; set; }

        [Column("passangers")]
        public int Passangers { get; set; }

        [Column("crew")]
        public int Crew { get; set; }

        [Column("maxSpeed")]
        public string MaxSpeed { get; set; }

        [Column("length")]
        public string Length { get; set; }

        [Column("costInCredits")]
        public double CostInCredits { get; set; }

        [Column("manufacturer")]
        public string Manufacturer { get; set; }

        [Column("model")]
        public int Model { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("consumables")]
        public string Consumables { get; set; }

        [Column("movies")]
        public List<long> Movies { get; set; }
    }
}
