using fakeLook_models.Models;
using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikesRepository _repo;

        public LikesController(ILikesRepository repo)
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
        [ResponseType(typeof(Like))]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public JsonResult GetAllLikesByPostId(int id)
        {
            return new JsonResult(_repo.GetAllByPostId(id));
        }

        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult<Like>> Add([FromBody] Like like)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            like.UserId = user.Id;
            var newLike = await _repo.Add(like);
            return CreatedAtAction(nameof(Add), new { id = newLike.Id }, newLike);
        }

        [HttpPatch]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult> UpdateLike([FromBody] Like like)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            like.UserId = user.Id;
            try
            {
                await _repo.Edit(like);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            return NoContent();
        }
    }
}

