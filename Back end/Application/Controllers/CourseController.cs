using DataAccessLayer.IRepository;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo courseDLL;

        public CourseController(ICourseRepo courseDLL)
        {
            this.courseDLL = courseDLL;
        }
        [HttpPost("/createCourse/")]
        public IActionResult CreateCourse(Course course)
        {
            try
            {
                courseDLL.CreateCourse(course);
                return Ok("Added");
            }
            catch (Exception e)
            {
                return BadRequest("Course not found!");
            }
        }
        [HttpGet("/readCourse/{id}")]
        public IActionResult ReadCourse(int id)
        {
            try
            {
                var task = courseDLL.ReadCourse(id);
                return Ok(task);
            }
            catch (Exception e)
            {
                return BadRequest("Failed");
            }
        }
        [HttpPut("/updateCourse/")]
        public IActionResult UpdateTask(Course task)
        {
            try
            {
                if (!courseDLL.UpdateCourse(task))
                {
                    return BadRequest("Could not update entity.");
                }
                return Ok("Course Updated!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while updating the entity! --> " + e.Message);
            }
        }
        [HttpDelete("/deleteCourse/{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                if (!courseDLL.DeleteCourse(id))
                {
                    return BadRequest("Could not delete entity.");
                }
                return Ok("Course Deleted!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while deliting the entity! --> " + e.Message);
            }
        }
    }
}
