using DataAccessLayer.IRepo;
using DataAccessLayer.Model;
using ApplicationLayer.Compression;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Utility : ControllerBase
    {
        [HttpGet("/date_to_number/{date}")]
        public IActionResult ReaddDailyList(string date)
        {
            return Ok(Hashing.dateToNumber(date));
        }

        [HttpGet("/number_to_date/{number}")]
        public IActionResult ReaddDailyList(int number)
        {
            return Ok(Hashing.numberToDate(number));
        }
        [HttpGet("/authentication/get_hash/{plainText}")]
        public IActionResult getHash(string plainText)
        {
            return Ok(ComputeSHA512(plainText));
        }

        static string ComputeSHA512(string s)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashValue = sha512.ComputeHash(Encoding.UTF8.GetBytes(s));
                foreach (byte b in hashValue)
                {
                    sb.Append($"{b:X2}");
                }
            }

            return sb.ToString();
        }
    }
}