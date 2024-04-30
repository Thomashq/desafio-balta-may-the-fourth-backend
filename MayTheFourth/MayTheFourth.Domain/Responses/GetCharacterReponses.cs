using MayTheFourth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Domain.Responses
{
    public class GetCharacterReponses
    {
        public string Name { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public string HairColor { get; set; }

        public string SkinColor { get; set; }

        public string EyeColor { get; set; }

        public string BirthYear { get; set; }

        public string Gender { get; set; }

        public List<dynamic> Planets { get; set; } = [];

        public List<dynamic> Movies { get; set; } = [];
    }
}
