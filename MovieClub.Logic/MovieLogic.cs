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

        public void AddMovie(MovieCreateUpdateDto dto)
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

        public IEnumerable<MovieShortViewDto> GetAllMovies()
        {
            return repo.GetAll().Select(x => 
                new MovieShortViewDto()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Genre = x.Genre
                }
            );
        }

        public void DeleteMovie(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateMovie(string id, MovieCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            old.Title = dto.Title;
            old.Genre = dto.Genre;
            repo.Update(old);
        }

        public MovieViewDto GetMovie(string id)
        {
            var model = repo.FindById(id);
            return new MovieViewDto()
            {
                Id = model.Id,
                Title = model.Title,
                Genre = model.Genre,
                Ratings = model.Ratings
            };
        }
    }
}
