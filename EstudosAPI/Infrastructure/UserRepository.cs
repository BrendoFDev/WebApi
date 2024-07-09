using EstudosAPI.IRepository;
using EstudosAPI.Model;

namespace EstudosAPI.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        ConnectionContext Context = new ConnectionContext();

        public void Add(User _User)
        {
            Context.User.Add(_User);
            Context.SaveChanges();
        }

        public List<User> Get()
        {
            return Context.User.ToList();
        }

        public User? GetUser(int id)
        {
            var User = Context.User.Find(id);
            return User;
        }
    }
}
