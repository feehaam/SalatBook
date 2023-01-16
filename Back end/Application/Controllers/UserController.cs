using DataAccessLayer.IRepo;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser userDLL;

        public UserController(IUser userDLL)
        {
            this.userDLL = userDLL;
        }

        [HttpPost("/create_user/")]
        public IActionResult CreateUser(User user)
        {
            try
            {
                if (!userDLL.CreateUser(user))
                {
                    return BadRequest("Duplicate or null! Could not create new entity.");
                }
                return Ok("Creation succesfull!");
            }
            catch (Exception e)
            {
                return BadRequest("Error while creating new user! --> " + e.Message);
            }
        }
        [HttpGet("/read_user/{id}")]
        public IActionResult ReadUser(int id)
        { 
            try
            {
                if(!userDLL.UserExists(id))
                {
                    return NotFound();
                }
                var user = userDLL.ReadUser(id);
                if (user == null) return BadRequest("Student doesn't exist, Or fail to parse!");
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound("Error while seraching user! --> " + e.Message);
            }
        }
        [HttpGet("/find_user/{emailOrUsername}")]
        public IActionResult FindUser(string emailOrUsername)
        {
            try
            {
                int userId = userDLL.GetUserId(emailOrUsername);
                return Ok(userId);
            }
            catch (Exception e)
            {
                return NotFound("Error while seraching user! --> " + e.Message);
            }
        }
        [HttpPut("/update_user/")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                if(user != null)
                if (!userDLL.UpdateUser(user))
                {
                    return BadRequest("Error while updating the user");
                }
                return Ok("Update succesfull");
            }
            catch (Exception e)
            {
                return NotFound("Error while updating user! --> " + e.Message);
            }
        }
        
        [HttpDelete("/delete_user/")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (!userDLL.UserExists(id)){
                    return NotFound();
                }
                if (!userDLL.DeleteUser(id))
                {
                    return BadRequest("Error while deleting the user");
                }
                return Ok("Deleted.");
            }
            catch (Exception e)
            {
                return NotFound("Error while deleting user! --> " + e.Message);
            }
        }
    }
}