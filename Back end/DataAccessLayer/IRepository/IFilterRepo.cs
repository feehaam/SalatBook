using DataAccessLayer.Model;

namespace DataAccessLayer.IRepository
{
    public interface IFilterRepo
    {
        List<Student> GetAllStudents();
        List<Student> GetStudentBy(string name);
        List<Student> SearchByWord(string word);
    }
}
