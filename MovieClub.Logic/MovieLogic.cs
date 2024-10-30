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
            // csak akkor mentsük el, hogyha nincs ilyen című
            if (repo.GetAll().FirstOrDefault(x => x.Title == m.Title) == null)
            {
                repo.Create(m);
            }
            else
            {
                //todo throw exception
            }
        }
    }
}
