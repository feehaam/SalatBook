
using asingment.Model;
using DataAccessLayer.IRepo;
using DataAccessLayer.Model;
using System.Xml.Linq;

namespace DataAccessLayer.Repository
{
    public class UserRepo : IUser
    {
        private readonly DataContext _context;
        public UserRepo(DataContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }
        public User ReadUser(int id)
        {
            User user = _context.Users.Where(x => x.Id == id).First();
            return user;
        }
        public User FindUser(string emailOrUsername)
        {
            User user = FindByEmail(emailOrUsername);
            if(user == null)
            {
                user = FindByUsername(emailOrUsername);
            }
            if (user == null) return null;
           return user;
        }
        private User FindByEmail(string email)
        {
            try
            {
                return _context.Users.Where(x => x.email.Equals(email)).ToList().ElementAt(0);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private User FindByUsername(string username)
        {
            try
            {
                return _context.Users.Where(x => x.username.Equals(username)).ToList().ElementAt(0);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public bool UpdateUser(User user)
        {
            _context.Update(user);
            return Save();
        }
        public bool DeleteUser(int id)
        {
            User user = ReadUser(id);
            _context.Users.Remove(user);
            return Save();
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
