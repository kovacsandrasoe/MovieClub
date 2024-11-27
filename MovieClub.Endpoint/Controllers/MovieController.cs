using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
using MovieClub.Entities.Helpers;
using MovieClub.Logic.Logic;

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
        [Authorize]
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
        [Authorize(Roles = "Admin")]
        public void DeleteMovie(string id)
        {
            logic.DeleteMovie(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void UpdateMovie(string id, [FromBody] MovieCreateUpdateDto dto)
        {
            logic.UpdateMovie(id, dto);
        }

        [HttpGet("{id}")]
        public MovieViewDto GetMovie(string id)
        {
            return logic.GetMovie(id);
        }
    }
}
