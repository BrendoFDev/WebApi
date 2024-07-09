using EstudosAPI.IRepository;
using EstudosAPI.Model;
using EstudosAPI.ViewModel;
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
        public IActionResult Add([FromForm] UserViewModel UserView)
        {
            var FilePath = Path.Combine("Storage", UserView.Photo.FileName);
            using Stream FileStream = new FileStream(FilePath, FileMode.Create);
            UserView.Photo.CopyTo(FileStream);

            User _user = new User(UserView.Name,UserView.Email, UserView.Login, UserView.Password, FilePath);
            userRepository.Add(_user);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<User> Users = userRepository.Get();
            return Ok(Users);
        }

        [HttpGet]
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
        [Route("{UserId}/DownloadPhoto")]
        public IActionResult DownloadUserPhoto(int UserId)
        {
            var User = userRepository.GetUser(UserId);
            var DataBytes = System.IO.File.ReadAllBytes(User.photo);

            return File(DataBytes, "image/png");
        }
    }
}
