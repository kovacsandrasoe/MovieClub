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
        public void AddMovie(MovieCreateUpdateDto dto)
        {
            logic.AddMovie(dto);
        }

        [HttpGet]
        public IEnumerable<MovieShortViewDto> GetAllMovies()
        {
            return logic.GetAllMovies();
        }

        [HttpDelete("{id}")]
        public void DeleteMovie(string id)
        {
            logic.DeleteMovie(id);
        }

        [HttpPut("{id}")]
        public void UpdateMovie(string id, [FromBody] MovieCreateUpdateDto dto)
        {
            logic.UpdateMovie(id, dto);
        }
    }
}
