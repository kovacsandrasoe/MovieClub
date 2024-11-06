using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public RatingController(RatingLogic logic)
        {
            this.logic = logic;
        }

        [HttpPost]
        public void AddRating(RatingCreateDto dto)
        {
            logic.AddRating(dto);
        }
    }
}
