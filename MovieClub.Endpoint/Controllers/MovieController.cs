using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
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
        public IActionResult AddMovie(MovieCreateUpdateDto dto)
        {
            try
            {
                logic.AddMovie(dto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
            
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

        [HttpGet("{id}")]
        public MovieViewDto GetMovie(string id)
        {
            return logic.GetMovie(id);
        }
    }
}
