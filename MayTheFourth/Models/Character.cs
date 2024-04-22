using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Character : BaseModel
    {
        [Column("name")]
        public string Name { get; set; } = string.Empty;
        [Column("height")]
        public string Height { get; set; } = string.Empty;
        [Column("Weight")]
        public string Weight { get; set; } = string.Empty;
        [Column("HairColor")]
        public string HairColor { get; set; } = string.Empty;
        [Column("SkinColor")]
        public string SkinColor { get; set; } = string.Empty;
        [Column("EyeColor")]
        public string EyeColor { get; set; } = string.Empty;
        [Column("BirthYear")]
        public string BirthYear { get; set; } = string.Empty;
        [Column("Gender")]
        public string Gender { get; set; } = string.Empty;
        //[ForeignKey("Planet_Id")]
        [Column("Planet")]
        public string Planet { get; set; } = string.Empty;
        //[ForeignKey("Movies_Id")]
        [Column("Movies")]
        public List<string> Movies { get; set; } = [];
    }
}