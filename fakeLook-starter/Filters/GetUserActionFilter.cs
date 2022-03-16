using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace fakeLook_starter.Filters
{
    public class GetUserActionFilter : ActionFilterAttribute
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public GetUserActionFilter(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers.Where(header => header.Key == "Authorization").SingleOrDefault().Value.ToString().Split(" ")[1];
            var user = _userRepository.GetById(int.Parse(_tokenService.GetPayload(token)));
            context.HttpContext.Request.RouteValues.Add("user", user);
        }
    }
}
