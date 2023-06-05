using haymatlos_backend.Models;
using haymatlos_backend.Services.userservices;
using Microsoft.AspNetCore.Mvc;

namespace haymatlos_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
 
        public class UsersController : Controller
        {
            private readonly IUserService userService;

            public UsersController(IUserService userServicee)
            {
                userService = userServicee;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var result = await userService.GetUserList();
                return Ok(result);
            }

           [HttpGet("{id:int}")]
            public async Task<IActionResult> GetUser(int id)
            {
                var result = await userService.GetUser(id);
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> AddUser([FromBody] UserModel user)
            {
                var result = await userService.CreateUser(user);
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateUser([FromBody] UserModel user)
            {
                var result = await userService.UpdateUser(user);
                return Ok(result);
            }

            [HttpDelete("{id:int}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                var result = await userService.DeleteUser(id);
                return Ok(result);
            }
        }
    }

