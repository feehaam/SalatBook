using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo studentDll;

        public StudentController(IStudentRepo studentDll)
        {
            this.studentDll = studentDll;
        }

        [HttpPost("/createStudent/")]
        public IActionResult CreatePerson(Student person)
        {
            try
            {
                if (!studentDll.CreateStudent(person))
                {
                    return BadRequest("Duplicate or null! Could not create new entity.");
                }
                return Ok("Creation succesfull!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while creating the entity! --> " + e.Message);
            }
        }
        [HttpGet("/readStudent{id}")]
        public IActionResult ReadStudent(int id)
        {
            try
            {
                var student = studentDll.ReadStudent(id);
                if (student == null) return BadRequest("Student doesn't exist");
                return Ok(student);
            }
            catch (Exception e)
            {
                return NotFound("Error while searching! --> " + e.Message);
            }
        }
        [HttpPut("/updateStudent/")]
        public IActionResult UpdateStudent(Student student)
        {
            try
            {
                if (!studentDll.UpdateStudent(student))
                {
                    return BadRequest("Could not update entity.");
                }
                return Ok("Person Updated!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while updating the entity! --> " + e.Message);
            }
        }
        [HttpDelete("/deleteStudent/")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                if (!studentDll.DeleteStudent(id))
                {
                    return BadRequest("Could not delete entity. Student with this id may not exist.");
                }
                return Ok("Student Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while deliting the entity! --> " + e.Message);
            }
        }
    }
}
