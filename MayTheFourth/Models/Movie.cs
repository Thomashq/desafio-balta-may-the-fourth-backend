using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Movie : BaseModel
    {
        [Column("title")]
        public string? Title { get; set; }

        [Column("episode")]
        public int Episode { get; set; }

        [Column("openingCrawl")]
        public string? OpeningCrawl { get; set; }

        [Column("director")]
        public string? Director { get; set; }

        [Column("producer")]
        public string? Producer { get; set; }

        [Column("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [Column("characters")]
        //[ForeignKey("characterId")]
        public List<string>? Characters { get; set; }

        [Column("planets")]
        //[ForeignKey("planetId")]
        public List<string>? Planets { get; set; }

        [Column("vehicles")]
        //[ForeignKey("vehicleId")]
        public List<string>? Vehicles { get; set; }

        [Column("starChips")]
        //[ForeignKey("starChipId")]
        public List<string>? StarChips { get; set; }

    }
}