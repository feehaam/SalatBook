using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class FilterRepo : IFilterRepo
    {
        private readonly DataContext _context;

        public FilterRepo(DataContext context)
        {
            _context = context;
        }


        public List<Student> GetAllStudents()
        {
            return _context.Students.OrderBy(j => j.Id).ToList();
        }

        public List<Student> GetStudentBy(string name)
        {
            return _context.Students.Where(i => i.Name.Contains(name)).ToList();
        }

        List<Student> IFilterRepo.SearchByWord(string word)
        {
            return _context.Students.Where(i => i.Name.Contains(word) || i.Id.ToString().Contains(word)).ToList();
        }
    }
}
