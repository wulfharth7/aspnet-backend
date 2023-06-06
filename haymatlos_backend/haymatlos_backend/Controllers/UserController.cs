using haymatlos_backend.Hubs;
using haymatlos_backend.Models;
using haymatlos_backend.Services.userservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace haymatlos_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
 
        public class UsersController : Controller
        {
            private readonly IUserService userService;
            private IHubContext<UserHub, IUserHub> userHub;

        public UsersController(IUserService userServicee, IHubContext<UserHub, IUserHub> _userHub)
            {
                userService = userServicee;
                userHub = _userHub;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var result = await userService.GetUserList();
                return Ok(result);
            }

           [HttpGet("{uuid}")]
            public async Task<IActionResult> GetUser(string uuid)
            {
                var result = await userService.GetUser(uuid);
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> AddUser([FromBody] UserModel user)
            {
                var result = await userService.CreateUser(user);
                await userHub.Clients.All.AddUser(user);
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

