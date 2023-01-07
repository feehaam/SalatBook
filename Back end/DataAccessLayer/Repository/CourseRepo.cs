using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public class CourseRepo : ICourseRepo
    {
        private readonly DataContext _context;
        private IHelperRepo _helperRepo;

        public CourseRepo(DataContext context)
        {
            _context = context;
            _helperRepo = new HelperRepo(context);
        }
        public Course ReadCourse(int id)
        {
            var task = _context.Courses.First(x => x.Id == id);
            return task;
        }

        public bool UpdateCourse(Course course)
        {
            _context.Update(course);
            _helperRepo.Save();
            return true;
        }

        public bool DeleteCourse(int id)
        {
            _context.Remove(ReadCourse(id));
            _helperRepo.Save();
            return true;
        }

        public void CreateCourse(Course course)
        {
            _context.Add(course);
            _helperRepo.Save();
        }
    }
}
