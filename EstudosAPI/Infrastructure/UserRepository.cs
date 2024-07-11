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

        public List<User> Get(int PageNumber, int RegisterPerPage)
        {
            return Context.User.Skip(PageNumber * RegisterPerPage).Take(RegisterPerPage).ToList();
        }

        public User? GetUser(int id)
        {
            var User = Context.User.Find(id);
            return User;
        }

        public User? GetUserByLoginAndPassword(string login, string password)
        {
            var user = Context.User.Where(x=>x.login == login && x.senha == password);
            return user.FirstOrDefault();
        }
    }
}
