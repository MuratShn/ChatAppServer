using Business.Features.Commands.Chat.AddChat;
using Business.Features.Queries.Chat.ChatGroup;
using Business.Features.Queries.Chat.GetChatDetail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("getMyChats")]
        public async Task<IActionResult> GetMyChats()
        {


            var request = new GetMyChatGroupQueryRequest() { UserId = User.Identities.First().Name };

            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("getChatDetail")]
        public async Task<IActionResult> GetChatDetail([FromQuery]GetChatDetailQueryRequest request)
        {
            /*
             * User Sayısı 2den fazla ise grup kabul edıcez aslında onun ıcın bır paratmerede koyabılırdık databse 
             * userların kullanıcı adını ve grup bilgisi alıcaz 
             */
            request.MyUserId = User.Identities.First().Name;
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("addChat")]
        public async Task<IActionResult> AddChat(AddChatCommandRequest request)
        {
            request.CreateUserId = User.Identities.First().Name;
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
