using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieClub.Data;
using MovieClub.Entities.Dtos.Rating;
using MovieClub.Logic.Logic;

namespace MovieClub.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {
        RatingLogic logic;
        UserManager<AppUser> userManager;

        public RatingController(RatingLogic logic, UserManager<AppUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task AddRating(RatingCreateDto dto)
        {
            var user = await userManager.GetUserAsync(User);

            logic.AddRating(dto, user.Id);
        }
    }
}
