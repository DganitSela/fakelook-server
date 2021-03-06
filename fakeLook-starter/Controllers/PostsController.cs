using fakeLook_models.Models;
using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public JsonResult GetAll()
        {
            return new JsonResult(_repo.GetAll());
        }

        [HttpGet("filter")]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public IActionResult GetAll([FromQuery] PostParameters postParameters)
        {
            if (!postParameters.ValidDateRange)
            {
                return BadRequest("Date range not valid.");
            }
            return new JsonResult(_repo.GetAll(postParameters));
        }

        [HttpGet("{id}")]
        [ResponseType(typeof(Post))]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public JsonResult Get(int id)
        {
            return new JsonResult(_repo.GetById(id));
        }

        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult<Post>> Add([FromBody] Post post)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            post.UserId = user.Id;
            var newPost = await _repo.Add(post);
            return CreatedAtAction(nameof(Add), new { id = newPost.Id }, newPost);
        }

        [HttpPatch("{id}")]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult> UpdatePost(int id, [FromBody] Post post)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            if (id != post.Id)
            {
                return BadRequest();
            } else if(user.Id != post.UserId)
            {
                return BadRequest("You don't have permissions to edit this post.");
            }
            await _repo.Edit(post);
            return NoContent();
        }
    }

    // Class that holds a filter parameters with default values.
    public class PostParameters
    {
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.Now;

        public List<int> Publishers { get; set; } = new List<int>();

        public List<string> Tags { get; set; } = new List<string>();

        public List<int> TaggedUsers { get; set; } = new List<int>();

        public bool ValidDateRange => MaxDate >= MinDate;
    }
}
