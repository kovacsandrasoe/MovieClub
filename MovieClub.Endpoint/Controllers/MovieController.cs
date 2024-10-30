using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
using MovieClub.Logic;

namespace MovieClub.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieLogic logic;

        public MovieController(MovieLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddMovie(MovieCreateDto dto)
        {
            logic.AddMovie(dto);
        }

        [HttpGet]
        public IEnumerable<Movie> GetAllMovies()
        {
            return logic.GetAllMovies();
        }
    }
}
