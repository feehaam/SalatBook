using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepo
{
    public interface IUser
    {
        public bool CreateUser(User user);
        public User ReadUser(int id);
        public User FindUser(string emailOrUsername);
        public bool DeleteUser(int id);
        public bool UpdateUser(User user);
        public bool UserExists(int id);
    }
}
