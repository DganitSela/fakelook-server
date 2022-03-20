using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace fakeLook_starter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository _repo;

        public CommentsController(ICommentsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(_repo.GetAll());
        }

        [HttpGet("post/{id}")]
        public JsonResult GetAllCommentsByPostId(int id)
        {
            return new JsonResult(_repo.GetAllByPostId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Add([FromBody] Comment comment)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            comment.UserId = user.Id;
            var newComment = await _repo.Add(comment);
            return CreatedAtAction(nameof(GetAll), new { id = newComment.Id }, newComment);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateComment(int id, [FromBody] Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            await _repo.Edit(comment);
            return NoContent();
        }





    }
}
