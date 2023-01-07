using DataAccessLayer.Model;

namespace DataAccessLayer.IRepository
{
    public interface IStudentRepo
    {
        bool CreateStudent(Student student);
        Student ReadStudent(int id);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int id);
    }
}
