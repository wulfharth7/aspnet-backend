using haymatlos_backend.Hubs;
using haymatlos_backend.Models;
using haymatlos_backend.Services.userservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Web.Http.Controllers;

namespace haymatlos_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
 
        public class UsersController : Controller
        {
            private readonly IUserService userService;
            private readonly IHubContext<UserHub> userHub;

        public UsersController(IUserService userServicee, IHubContext<UserHub> _userHub)
            {
                userService = userServicee;
                userHub = _userHub;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                var result = await userService.GetUserList();
                await showDataFromApi();
                return Ok(result);
            }

           [HttpGet("{uuid}")]
            public async Task<IActionResult> GetUser(string uuid)
            {
                var result = await userService.GetUser(uuid);
                await showDataFromApi();
                return Ok(result);
            }

            [HttpPost]
            public async Task<IActionResult> AddUser([FromBody] UserModel user)
            {
                var result = await userService.CreateUser(user);
                await showDataFromApi();
                return Ok(result);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateUser([FromBody] UserModel user)
            {
                var result = await userService.UpdateUser(user);
                await showDataFromApi();
                return Ok(result);
            }

            [HttpDelete("{uuid}")]
            public async Task<IActionResult> DeleteUser(string uuid)
            {
                var result = await userService.DeleteUser(uuid);
                await showDataFromApi();
                return Ok(result);
            }
            [HttpGet("data")]
            public async Task showDataFromApi()
            {
                var users_ = await userService.GetUserList();
                await userHub.Clients.All.SendAsync("ShowAllUserswithSignalR", users_);
            }
        }
    }

