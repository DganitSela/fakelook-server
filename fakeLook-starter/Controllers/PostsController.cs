using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        [ResponseType(typeof(Post))]
        public JsonResult Get(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Add([FromBody] Post post)
        {
            var newPost = await _repo.Add(post);
            return CreatedAtAction(nameof(GetAll), new { id = newPost.Id }, newPost);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }
            await _repo.Edit(post);
            return NoContent();
        }
    }
}
