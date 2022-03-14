using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("getById")]
        public JsonResult GetUserById(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        public JsonResult SignUp(User user)
        {
            return new JsonResult(_repo.Add(user));
        }
    }
}
