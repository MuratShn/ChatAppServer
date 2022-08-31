using Business.Features.Commands.CreateUser;
using Business.Features.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(CreateUserCommandRequest user)
        {
            var result = await _mediator.Send(user);
            return Ok(result);
        }
        [Authorize]
        [HttpGet("getUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var request = new GetUserInfoQueryRequest() { UserId = User.Identities.First().Name};

            var result = _mediator.Send(request);
            
            return Ok(result);
        }
    }
}
