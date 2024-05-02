using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Character : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("height")]
        public string Height { get; set; }

        [Column("weight")]
        public string Weight { get; set; }

        [Column("hairColor")]
        public string HairColor { get; set; }

        [Column("skinColor")]
        public string SkinColor { get; set; }

        [Column("eyeColor")]
        public string EyeColor { get; set; }

        [Column("birthYear")]
        public string BirthYear { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("planet")]
        public List<long> Planet { get; set; }

        [Column("movies")]
        public List<long> Movies { get; set; }
    }
}