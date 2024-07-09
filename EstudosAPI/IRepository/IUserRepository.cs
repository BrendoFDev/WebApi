using EstudosAPI.Model;
namespace EstudosAPI.IRepository
{
    public interface IUserRepository
    {
        void Add(User _User);
        List<User> Get();
        User? GetUser(int id);
    }
}
