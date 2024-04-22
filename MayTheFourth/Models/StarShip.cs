using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class StarShip:BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("model")]
        public string Model { get; set; }

        [Column("manufacturer")]
        public string Manufacturer { get; set; }

        [Column("costInCredits")]
        public long CostInCredits { get; set; }

        [Column("length")]
        public string Length { get; set; }

        [Column("maxSpeed")]
        public string MaxSpeed { get; set; }

        [Column("crew")]
        public int Crew { get; set; }

        [Column("passangers")]
        public int Passangers { get; set; }

        [Column("cargoCapacity")]
        public string CargoCapacity { get; set; }

        [Column("hyperdriveRating")]
        public double HyperdriveRating { get; set; }

        [Column("mglt")]
        public double Mglt { get; set; }

        [Column("consumables")]
        public string Consumables { get; set; }

        [Column("class")]
        public string Class { get; set; }

    }
}
