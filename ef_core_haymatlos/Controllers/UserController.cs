using ef_core_haymatlos.Models;
using ef_core_haymatlos.Utils.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ef_core_haymatlos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDataProvider userDataProvider;
        public UserController(IUserDataProvider userDataProvider)
        {
            this.userDataProvider = userDataProvider;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userDataProvider.GetAllUsers();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Guid uuid = Guid.NewGuid();
                user.Uuid = uuid.ToString();
                userDataProvider.AddUser(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{uuid}")]
        public User GetSingleUser(string uuid)
        {
            return userDataProvider.GetSingleUser(uuid);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                userDataProvider.UpdateUser(user);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{uuid}")]
        public IActionResult Delete(string uuid)
        {
            var data = userDataProvider.GetSingleUser(uuid);
            if (data != null)
            {
                return NotFound();
            }
            userDataProvider.RemoveUser(uuid);
            return Ok();
        }
    }
}
