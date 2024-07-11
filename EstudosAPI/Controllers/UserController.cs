using EstudosAPI.IRepository;
using EstudosAPI.Model;
using EstudosAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstudosAPI.Controllers
{
    [ApiController]
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromForm] UserViewModel UserView)
        {
            if(UserView.Photo != null)
            {
                var FilePath = Path.Combine("Storage", UserView.Photo.FileName);
                using Stream FileStream = new FileStream(FilePath, FileMode.Create);
                UserView.Photo.CopyTo(FileStream);

                User _user = new User(UserView.Name, UserView.Email, UserView.Login, UserView.Password, FilePath);
                userRepository.Add(_user);
            }
            else
            {
                User _user = new User(UserView.Name, UserView.Email, UserView.Login, UserView.Password, string.Empty);
                userRepository.Add(_user);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int PageNumber,int RegisterPerPage)
        {
            List<User> Users = userRepository.Get(PageNumber,RegisterPerPage);
            return Ok(Users);
        }

        [HttpGet]
        [Authorize]
        [Route("{Login}/{Password}")]
        public IActionResult Get(string Login, string Password)
        {
            User? user = userRepository.GetUserByLoginAndPassword(Login, Password);
            return Ok(user);
        }

        [HttpGet]
        [Authorize]
        [Route("{UserId}")]
        public IActionResult GetUser(int UserId)
        {
            var User = userRepository.GetUser(UserId);

            if (User != null)
                return Ok(User);
            else
                return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("{UserId}/DownloadPhoto")]
        public IActionResult DownloadUserPhoto(int UserId)
        {
            var User = userRepository.GetUser(UserId);
            var DataBytes = System.IO.File.ReadAllBytes(User.photo);

            return File(DataBytes, "image/png");
        }
    }
}
