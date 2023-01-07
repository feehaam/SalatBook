using asingment.Model;
using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DataAccessLayer.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DataContext _context;
        private IHelperRepo _helperRepo;

        public StudentRepo(DataContext context, IHelperRepo helperRepo)
        {
            _context = context;
            _helperRepo = helperRepo;
        }

        public bool CreateStudent(Student student)
        {
            _context.Add(student);
            return _helperRepo.Save();
        }

        public Student ReadStudent(int id)
        {
            Student student = _context.Students.Where(x => x.Id == id).Include(x => x.Courses).ToList().First();
            return student;
        }

        public bool UpdateStudent(Student student)
        {
            DeleteStudent(student.Id);
            CreateStudent(student);
            _context.SaveChanges();
            _helperRepo.Save();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            //Student student = ReadStudent(id);
            //if (student != null && student.Courses != null)
            //{
            //    foreach (var task in student.Courses)
            //    {
            //        //student.DeleteTask(task.Id);
            //    }
            //    _context.Remove(ReadStudent(id));
            //    _helperRepo.Save();
            //    return true;
            //}
            //_helperRepo.Save();
            return false;
        }
    }
}
