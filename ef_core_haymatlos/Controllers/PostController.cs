using ef_core_haymatlos.Models;
using ef_core_haymatlos.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ef_core_haymatlos.Controllers
{
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostDataProvider postDataProvider;
        public PostController(IPostDataProvider postDataProvider)
        {
            this.postDataProvider = postDataProvider;
        }
        
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return postDataProvider.GetAllPosts();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                Guid uuid = Guid.NewGuid();
                post.Uuid = uuid.ToString();
                postDataProvider.AddPost(post);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{uuid}")]
        public Post GetSinglePost(string uuid)
        {
            return postDataProvider.GetSinglePost(uuid);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Post post)
        {
            if (ModelState.IsValid)
            {
                postDataProvider.UpdatePost(post);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var data = postDataProvider.GetSinglePost(uuid);
            if (data != null)
            {
                return NotFound();
            }
            postDataProvider.RemovePost(uuid);
            return Ok();
        }
    }
}
