using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MovieClub.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public void Register()
        {
            //var user = new IdentityUser("geza");
            
            
        }
    }
}
