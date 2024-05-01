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
        public List<long>? Characters { get; set; }

        [Column("planets")]
        public List<long> Planets { get; set; }

        [Column("vehicles")]
        public List<long> Vehicles { get; set; }

        [Column("starShips")]
        public List<long> StarShips { get; set; }
    }
}