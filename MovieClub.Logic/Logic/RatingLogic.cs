using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Rating;
using MovieClub.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Logic.Logic
{
    public class RatingLogic
    {
        Repository<Rating> repo;
        DtoProvider dtoProvider;

        public RatingLogic(Repository<Rating> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddRating(RatingCreateDto dto, string userId)
        {
            var model = dtoProvider.Mapper.Map<Rating>(dto);
            model.UserId = userId;
            repo.Create(model);
        }
    }
}
