using haymatlos_backend.Hubs;
using haymatlos_backend.Models;
using haymatlos_backend.Services.postservices;
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
            private readonly IPostService _postService;
            private readonly IHubContext<UserHub> userHub;
            private readonly IHubContext<PostHub> postHub;
        public UsersController(IUserService userServicee, IHubContext<UserHub> _userHub, IPostService postService, IHubContext<PostHub> _postHub)
            {
                userService = userServicee;
                _postService = postService;
                userHub = _userHub;
                postHub = _postHub;
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

            [HttpPut("{userId}")]
            public async Task<IActionResult> UpdateUser(string userId, [FromBody] UserModel user)
            {
                var result = await userService.UpdateUser(userId,user);
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
                var posts_ = await _postService.GetPostList();
                await postHub.Clients.All.SendAsync("showRelatedPosts", posts_);
                await userHub.Clients.All.SendAsync("ShowAllUserswithSignalR", users_);
            }
            
        }
    }

