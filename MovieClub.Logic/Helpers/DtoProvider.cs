using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieClub.Data;
using MovieClub.Entities;
using MovieClub.Entities.Dtos.Movie;
using MovieClub.Entities.Dtos.Rating;
using MovieClub.Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<AppUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.AverageRating = src.Ratings?.Count > 0 ? src.Ratings.Average(r => r.Rate) : 0;
                });

                cfg.CreateMap<AppUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });


                cfg.CreateMap<Movie, MovieViewDto>();
                cfg.CreateMap<MovieCreateUpdateDto, Movie>();
                cfg.CreateMap<RatingCreateDto, Rating>();
                cfg.CreateMap<Rating, RatingViewDto>()
                .AfterMap((src, dest) =>
                {
                    var user = userManager.Users.First(u => u.Id == src.UserId);
                    dest.UserFullName = user.LastName! + " " + user.FirstName;    
                });
            });

            Mapper = new Mapper(config);
        }
    }
}
