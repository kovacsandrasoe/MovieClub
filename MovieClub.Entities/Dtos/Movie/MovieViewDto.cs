using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieClub.Entities.Dtos.Rating;

namespace MovieClub.Entities.Dtos.Movie
{
    public class MovieViewDto
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public IEnumerable<RatingViewDto>? Ratings { get; set; }

        //extra property
        public int RatingCount => Ratings?.Count() ?? 0;

    }
}
