using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        UserManager<IdentityUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageRating = src.Ratings?.Count > 0 ? src.Ratings.Average(r => r.Rate) : 0;
                });


                cfg.CreateMap<Movie, MovieViewDto>();
                cfg.CreateMap<MovieCreateUpdateDto, Movie>();
                cfg.CreateMap<RatingCreateDto, Rating>();
                cfg.CreateMap<Rating, RatingViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.UserFullName = userManager.Users.First(u => u.Id == src.UserId).UserName!;    
                });
            });

            Mapper = new Mapper(config);
        }
    }
}
