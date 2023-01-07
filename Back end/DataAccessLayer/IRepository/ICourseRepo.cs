using DataAccessLayer.Model;

namespace DataAccessLayer.IRepository
{
    public interface ICourseRepo
    {
        void CreateCourse(Course course);
        Course ReadCourse(int id);
        bool UpdateCourse(Course course);
        bool DeleteCourse(int id);
    }
}
