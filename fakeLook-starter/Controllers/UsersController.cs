using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fakeLook_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }
        
        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_repo.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult GetUserById(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<User>> SignUp([FromBody] User user)
        {
            var newUser = await _repo.Add(user);
            return CreatedAtAction(nameof(GetAll), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }
            await _repo.Edit(user);
            return NoContent();
        }
    }
}
