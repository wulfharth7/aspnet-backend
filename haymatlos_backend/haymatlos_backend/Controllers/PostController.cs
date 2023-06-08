using haymatlos_backend.Hubs;
using haymatlos_backend.Models;
using haymatlos_backend.Services.postservices;
using haymatlos_backend.Services.userservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace haymatlos_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller
    {
        
        private readonly IPostService _postService;
        private readonly IHubContext<PostHub> postHub;

        public PostController(IPostService postService, IHubContext<PostHub> _postHub)
        {
            _postService = postService;
            postHub = _postHub;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _postService.GetPostList();
            await showDataFromApiPosts();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostModel post)
        {
            var result = await _postService.CreatePost(post);
            await showDataFromApiPosts();
            return Ok(result);
        }

        [HttpGet("data")]
        public async Task showDataFromApiPosts()
        {
            var posts_ = await _postService.GetPostList();
            await postHub.Clients.All.SendAsync("showRelatedPosts", posts_);
        }
    }
}
