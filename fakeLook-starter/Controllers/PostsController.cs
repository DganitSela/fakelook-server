using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repo;

        public PostsController(IPostRepository repo)
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
        [ResponseType(typeof(Post))]
        public JsonResult Get(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public async Task<Post> Add([FromBody]Post post)
        {
            return  await _repo.Add(post);
        }
    }
}
