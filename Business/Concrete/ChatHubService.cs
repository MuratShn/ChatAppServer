using Business.Features.Commands.Message.AddMessage;
using Core.Entities;
using Core.Hubs;
using DataAccess.Abstract.Chat;
using DataAccess.Abstract.ChatMember;
using Entities.DTO_S;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ChatHubService : IChatHubService
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatMemberReadRepository _chatMemberReadRepository;
        private readonly UserManager<AppUser> _userManager;

        public ChatHubService(IHubContext<ChatHub> hubContext, IChatMemberReadRepository chatMemberReadRepository, UserManager<AppUser> userManager)
        {
            _hubContext = hubContext;
            _chatMemberReadRepository = chatMemberReadRepository;
            _userManager = userManager;
        }

        public async Task SendMessage(AddMessageCommandRequest request)
        {

            var usersId = _chatMemberReadRepository.GetWhere(x => x.ChatId == Guid.Parse(request.ChatId)).Select(x => x.AppUserId).ToList();
            usersId.Add(request.SenderUserId);

            var clientsId = _userManager.Users.Where(x => usersId.Contains(x.Id)).Select(x => x.ClientId).ToList();

            var senderUserName = await _userManager.FindByIdAsync(request.SenderUserId);


            var result = new GetMessagesDto() { MessageContent = request.Message, MessageTime = DateTime.UtcNow, SenderUserName = senderUserName.UserName };
            await _hubContext.Clients.Clients(clientsId).SendAsync("receiveMessage", result);

        }
    }
}
