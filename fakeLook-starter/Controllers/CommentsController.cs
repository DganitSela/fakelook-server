using fakeLook_models.Models;
using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public JsonResult GetAll()
        {
            return new JsonResult(_repo.GetAll());
        }

        [HttpGet("post/{id}")]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public JsonResult GetAllCommentsByPostId(int id)
        {
            return new JsonResult(_repo.GetAllByPostId(id));
        }

        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult<Comment>> Add([FromBody] Comment comment)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            comment.UserId = user.Id;
            try
            {
                var newComment = await _repo.Add(comment);
                return CreatedAtAction(nameof(GetAll), new { id = newComment.Id }, newComment);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
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
