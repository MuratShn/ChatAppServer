using Business.Features.Commands.Message.AddMessage;
using Business.Features.Queries.Message.GetMessages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getMessages")]
        [Authorize]
        public async Task<IActionResult> GetMessages([FromQuery]GetMessagesQueryRequest request)
        {
            request.MyUserId = User.Identities.First().Name;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("addMessage")]
        [Authorize]
        public async Task<IActionResult> AddMessage([FromBody]AddMessageCommandRequest request)
        {
            request.SenderUserId = User.Identities.First().Name;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
