using MovieClub.Data;
using MovieClub.Entities;

namespace MovieClub.Logic
{
    public class MovieLogic
    {
        Repository<Movie> repo;

        public MovieLogic(Repository<Movie> repo)
        {
            this.repo = repo;
        }

        public void AddMovie()
        {
            
        }
    }
}
