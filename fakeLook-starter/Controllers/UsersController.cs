using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace fakeLook_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly ITokenService _tokenService;

        public UsersController(IUserRepository repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _repo.GetUser(user);
            if (dbUser == null)
            {
                return Problem("User not found.");
            }
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }

        [HttpPost]
        public async Task<ActionResult<User>> SignUp([FromBody] User user)
        {
            try
            {
                var newUser = await _repo.Add(user);
                return CreatedAtAction(nameof(GetAll), new { id = newUser.Id }, newUser);
            } catch(Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                await _repo.Edit(user);
            } catch(Exception e)
            {
                return Problem(e.Message);
            }
            return NoContent();
        }
    }
}
