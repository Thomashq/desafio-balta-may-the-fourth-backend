using MayTheFourth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayTheFourth.Domain.Responses
{
    public class GetMovieResponse
    {
        public string? Title { get; set; }

        public int Episode { get; set; }

        public string? OpeningCrawl { get; set; }

        public string? Director { get; set; }

        public string? Producer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<dynamic>? Characters { get; set; }

        public List<dynamic> Planets { get; set; }

        public List<dynamic> Vehicles { get; set; }

        public List<dynamic> StarShips { get; set; }
    }
}
