using DataAccessLayer.IRepo;
using ApplicationLayer.Compression;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.DTO;
using DataAccessLayer.Model;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport reportDLL;
        private readonly IUser userDLL;

        public ReportController(IReport reportDLL, IUser userDLL)
        {
            this.reportDLL = reportDLL;
            this.userDLL = userDLL;
        }

        [HttpPost("/add_daily_list/")]
        public IActionResult CreateDailyList(DailyDto day, int userId)
        {
            int value = Hashing.getHash(day);
            if (!reportDLL.AddToRecord(userId, value))
            {
                return BadRequest("Error while updating the user");
            }
            return Ok("Update succesfull");
        }

        [HttpGet("/get_daily_list{userId}/{date}/")]
        public IActionResult ReadDailyList(int userId, string date)
        { 
            List<int> records = reportDLL.ReadReport(userId);
            int dateInNum = Hashing.dateToNumber(date);
            foreach(int record in records)
            {
                int recDate = record / 10000;
                if (recDate == dateInNum) return Ok(Hashing.getObject(record));
            }
            return NotFound();
        }

        [HttpPut("/update_daily_list/")]
        public IActionResult UpdateDailyList(int userId, DailyDto day)
        {
            List<int> records = reportDLL.ReadReport(userId);
            int dateInNum = Hashing.dateToNumber(day.Date);
            int value = Hashing.getHash(day);
            foreach (int record in records)
            {
                int recDate = record / 10000;
                if (recDate == dateInNum)
                {
                    if (reportDLL.RemoveFromRecord(userId, record))
                        if (reportDLL.AddToRecord(userId, value))
                            return Ok("Updated.");
                        else break;
                    else break;
                }
            }
            return NotFound();
        }

        [HttpDelete("/delete_daily_list/")]
        public IActionResult DeleteDailyList(int userId, string date)
        {
            List<int> records = reportDLL.ReadReport(userId);
            int dateInNum = Hashing.dateToNumber(date);
            foreach (int record in records)
            {
                int recDate = record / 10000;
                if (recDate == dateInNum)
                {
                    if (reportDLL.RemoveFromRecord(userId, record))
                        return Ok("Deleted");
                    else break;
                }
            }
            return NotFound();
        }

        [HttpGet("/get_full_list/{userId}")]
        public IActionResult GetFullList(int userId)
        {
            try
            {
                List<int> report = reportDLL.ReadReport(userId);
                return Ok(Hashing.getObject(report));
            }
            catch (Exception e)
            {
                return NotFound("Error while seraching! --> " + e.Message);
            }
        }
        
        [HttpDelete("/clear_full_list/")]
        public IActionResult ClearFullList(int userId)
        {
            try
            {
                bool done = reportDLL.ClearList(userId);
                if (done) return Ok("Cleared list.");
            }
            catch (Exception e) { }
            return NotFound();
        }
    }
}