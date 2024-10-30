using AutoMapper;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
using MovieClub.Entities.Dtos.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Logic.Helpers
{
    public class DtoProvider
    {
        public Mapper Mapper { get; }

        public DtoProvider()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieShortViewDto>();
                cfg.CreateMap<Movie, MovieViewDto>();
                cfg.CreateMap<MovieCreateUpdateDto, Movie>();
                cfg.CreateMap<RatingCreateDto, Rating>();
            });

            Mapper = new Mapper(config);
        }
    }
}
