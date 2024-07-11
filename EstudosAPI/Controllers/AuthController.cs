using Microsoft.AspNetCore.Mvc;
using EstudosAPI.Model;
using EstudosAPI.IRepository;
using EstudosAPI.Infrastructure;
using EstudosAPI.Services;

namespace EstudosAPI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;

        public AuthController(IUserRepository userRepository) 
        { 
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Route("Api/v1/GetToken")]
        public IActionResult GetToken(string Login, string Password)
        {
            User? user = userRepository.GetUserByLoginAndPassword(Login, Password);
            if (user != null)
            {
                var token = TokenService.GenerateToken(user);
                return Ok(token);
            }
            else
                return BadRequest("User or Password Invalid");
            
        }
    }
}
