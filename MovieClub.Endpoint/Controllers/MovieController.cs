using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;

namespace MovieClub.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieClubContext ctx;

        public MovieController(MovieClubContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost]
        public void AddMovie(Movie movie)
        {
            ctx.Movies.Add(movie);
            ctx.SaveChanges();
        }
    }
}
