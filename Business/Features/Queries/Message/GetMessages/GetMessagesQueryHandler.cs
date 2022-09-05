using Core.Entities;
using DataAccess.Abstract.Message;
using Entities.DTO_S;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Message.GetMessages
{
    public class GetMessagesQueryHandler : IRequestHandler<GetMessagesQueryRequest, GetMessagesQueryResponse>
    {
        private readonly IMessageReadRepository _messageReadRepository;
        private readonly UserManager<AppUser> _userManager;
        public GetMessagesQueryHandler(IMessageReadRepository messageReadRepository, UserManager<AppUser> userManager)
        {
            _messageReadRepository = messageReadRepository;
            _userManager = userManager;
        }

        public async Task<GetMessagesQueryResponse> Handle(GetMessagesQueryRequest request, CancellationToken cancellationToken)
        {
            var messages = _messageReadRepository.GetWhere(x => x.ChatId == Guid.Parse(request.ChatId)).ToList();

            if (messages != null)
            {
                var messagesList = new List<GetMessagesDto>();
                
                foreach (var item in messages)
                {
                    var user = await _userManager.FindByIdAsync(item.SenderUserId);

                    messagesList.Add(new()
                    {
                        MessageContent = item.MessageContent,
                        SenderUserName = user.UserName,
                        MessageTime = item.CreatedDate
                    });
                }
                var myUserName = await _userManager.FindByIdAsync(request.MyUserId);
                return new()
                {
                    MyUserName = myUserName.UserName,
                    Messages = messagesList,
                };
            }

            throw new NotImplementedException();
        }
    }
}
