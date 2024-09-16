using Microsoft.AspNetCore.Mvc;

namespace ProjetoEstacio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
       [HttpGet("get-all-users")]
        public IActionResult GetAllUsers()
        {
            return Ok("hello");
        }
        
        [HttpGet("get-user")]
        public IActionResult GetUser()
        {
            return Ok("hello");
        }
    }
}