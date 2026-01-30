using CMS.Application.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

    }
}
