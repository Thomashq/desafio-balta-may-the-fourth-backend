using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Movie : BaseModel
    {
        [Column("Title")]
        public string? Title { get; set; }

        [Column("Episode")]
        public int Episode { get; set; }

        [Column("OpeningCrawl")]
        public string? OpeningCrawl { get; set; }

        [Column("Director")]
        public string? Director { get; set; }

        [Column("Producer")]
        public string? Producer { get; set; }

        [Column("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Column("Characters")]
        //[ForeignKey("CharacterId")]
        public List<string>? Characters { get; set; }

        [Column("Planets")]
        //[ForeignKey("PlanetId")]
        public List<string>? Planets { get; set; }

        [Column("Vehicles")]
        //[ForeignKey("VehicleId")]
        public List<string>? Vehicles { get; set; }

        [Column("StarChips")]
        //[ForeignKey("StarChipId")]
        public List<string>? StarChips { get; set; }

    }
}