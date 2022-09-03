using Business.Features.Queries.Chat.ChatGroup;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getMyChats")]
        [Authorize]
        public async Task<IActionResult> GetMyChats()
        {


            var request = new GetMyChatGroupQueryRequest() { UserId = User.Identities.First().Name };

            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
