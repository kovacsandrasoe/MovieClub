using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Entities.Dtos.Movie
{
    public class MovieShortViewDto
    {
        public string Id { get; set; } = "";

        public string Title { get; set; } = "";

        public string Genre { get; set; } = "";
    }
}
