
using asingment.Model;
using DataAccessLayer.IRepo;
using DataAccessLayer.Model;
using System.Xml.Linq;

namespace DataAccessLayer.Repository
{
    public class UserRepo : IUser
    {
        private readonly DataContext context;
        public UserRepo(DataContext context)
        {
           this.context = context;
        }
        public bool CreateUser(User user)
        {
            context.Add(user);
            return Save();
        }
        public User ReadUser(int id)
        {
            User user = context.Users.Single(x => x.Id == id);
            return user;
        }
        public int GetUserId(string emailOrUsername)
        {
            if(emailOrUsername == null) { return -1; }
            User user = context.Users.Single(x => x.username == emailOrUsername || x.email == emailOrUsername);
            return user == null ? -1 : user.Id;
        }
        public bool UpdateUser(User user)
        {
            context.Update(user);
            return Save();
        }
        public bool DeleteUser(int id)
        {
            User user = ReadUser(id);
            context.Users.Remove(user);
            return Save();
        }
        public bool UserExists(int id)
        {
            return context.Users.Any(x => x.Id == id);
        }
        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
