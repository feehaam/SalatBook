using asingment.Model;
using DataAccessLayer.IRepo;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class ReportRepo : IReport
    {
        
        private readonly IUser userDLL;
        private readonly DataContext context;
        public ReportRepo(IUser userDLL, DataContext context)
        {
            this.userDLL = userDLL;
            this.context = context;
        }

        public bool AddToRecord(int userId, int value)
        {
            User user = userDLL.ReadUser(userId);
            user.records.Add(value);
            return userDLL.UpdateUser(user);
        }

        public List<int> ReadReport(int Id)
        {
            if (userDLL.UserExists(Id))
            {
                return userDLL.ReadUser(Id).records;
            }
            else return null;
        }
        public bool RemoveFromRecord(int userId, int value)
        {
            try
            {
                User user = userDLL.ReadUser(userId);
                user.records.Remove(value);
                return userDLL.UpdateUser(user);
            }
            catch
            {
                return false;
            }
        }
        public bool ClearList(int userId)
        {
            User user = userDLL.ReadUser(userId);
            user.records.Clear();
            return userDLL.UpdateUser(user);
        }
    }
}
