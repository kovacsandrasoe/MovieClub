using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;

namespace MovieClub.Logic
{
    public class MovieLogic
    {
        Repository<Movie> repo;

        public MovieLogic(Repository<Movie> repo)
        {
            this.repo = repo;
        }

        public void AddMovie(MovieCreateDto dto)
        {
            Movie m = new Movie(dto.Title, dto.Genre);
            repo.Create(m);
        }
    }
}
