using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
using MovieClub.Logic.Helpers;

namespace MovieClub.Logic.Logic
{
    public class MovieLogic
    {
        Repository<Movie> repo;
        DtoProvider dtoProvider;

        public MovieLogic(Repository<Movie> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddMovie(MovieCreateUpdateDto dto)
        {
            Movie m = dtoProvider.Mapper.Map<Movie>(dto);

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
                dtoProvider.Mapper.Map<MovieShortViewDto>(x)
            );
        }

        public void DeleteMovie(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateMovie(string id, MovieCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public MovieViewDto GetMovie(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<MovieViewDto>(model);
        }
    }
}
