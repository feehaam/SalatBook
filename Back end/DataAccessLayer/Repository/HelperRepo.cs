using asingment.Model;
using DataAccessLayer.IRepository;

namespace DataAccessLayer.Repository
{
    public class HelperRepo : IHelperRepo
    {
        private readonly DataContext _context;
        public HelperRepo(DataContext context)
        {
            _context = context;
        }
        
        public bool StudentExists(string name)
        {
            return _context.Students.Any(x => x.Name == name);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
