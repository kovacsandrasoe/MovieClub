using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;

namespace MovieClub.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        Repository<Movie> repo;

        public MovieController(Repository<Movie> repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        public void AddMovie(Movie movie)
        {
            repo.Create(movie);
        }
    }
}
