using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Entities.Dtos.Movie
{
    public class MovieCreateUpdateDto
    {
        public required string Title { get; set; } = "";

        public required string Genre { get; set; } = "";
    }
}
