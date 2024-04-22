using System.ComponentModel.DataAnnotations.Schema;

namespace MayTheFourth.Models
{
    public class Movie:BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
