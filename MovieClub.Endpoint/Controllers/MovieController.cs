using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities;

namespace MovieClub.Endpoint.Controllers
{
    public class MovieCreateDto
    {
        public string Title { get; set; }

        public string Genre { get; set; }
    }


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
        public void AddMovie(MovieCreateDto dto)
        {
            var m = new Movie(dto.Title, dto.Genre);
            repo.Create(m);
        }
    }
}
