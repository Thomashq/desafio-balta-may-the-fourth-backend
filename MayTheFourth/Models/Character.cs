﻿using System.ComponentModel.DataAnnotations.Schema;

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
        //[ForeignKey("Planet_Id")]
        [Column("planet")]
        public string Planet { get; set; }
        //[ForeignKey("Movies_Id")]
        [Column("movies")]
        public List<string> Movies { get; set; }
    }
}