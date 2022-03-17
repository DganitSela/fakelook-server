using fakeLook_models.Models;
using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Web.Http.Description;

namespace fakeLook_starter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagsRepository _repo;

        public TagsController(ITagsRepository repo)
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

        [HttpPost]
        [TypeFilter(typeof(GetUserActionFilter))]
        [Authorize]
        public async Task<ActionResult<Tag>> Add([FromBody] Tag tag)
        {
            var newTag = await _repo.Add(tag);
            return CreatedAtAction(nameof(Add), new { id = newTag.Id }, newTag);
        }
    }
}
