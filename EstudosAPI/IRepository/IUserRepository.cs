using EstudosAPI.Model;
namespace EstudosAPI.IRepository
{
    public interface IUserRepository
    {
        void Add(User _User);
        List<User> Get(int PageNumber, int RegisterPerPage);
        User? GetUser(int id);
        User? GetUserByLoginAndPassword(string login, string password);
    }
}
