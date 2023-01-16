using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepo
{
    public interface IReport
    {
        public List<int> ReadReport(int Id);
        public bool AddToRecord(int userId, int value);
        public bool RemoveFromRecord(int userId, int value);
        public bool ClearList(int userId);
    }
}
