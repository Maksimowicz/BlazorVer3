using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace RESTService.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class HashController : ControllerBase
    {
        [HttpGet(Name = "GetHashSHA256")]
        public string GetHashSHA256(string valueToHash)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(valueToHash))).Replace("-", String.Empty);
        }

        [HttpGet(Name = "GetHashSHA512")]
        public string GetHashSHA512(string valueToHash)
        {
            return BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(valueToHash))).Replace("-", String.Empty);
        }

        [HttpGet(Name = "MD5")]
        public string GetHashMD5(string valueToHash)
        {
            return BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(valueToHash))).Replace("-", String.Empty);
        }

    }
}
