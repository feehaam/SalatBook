using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class User
    {
        public int Id { get; set; }
        public string ?username { get; set; }
        public string ?email { get; set; }
        public string ?password { get; set; }
        public string ?fullName { get; set; }
        public List<int> ?records { get; set; }
    }
}
