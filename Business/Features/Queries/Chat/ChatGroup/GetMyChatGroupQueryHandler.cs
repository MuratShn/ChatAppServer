using DataAccess.Abstract.Chat;
using DataAccess.Abstract.ChatMember;
using DataAccess.Abstract.Message;
using Entities.Abstract;
using Entities.DTO_S;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.ChatGroup
{
    public class GetMyChatGroupQueryHandler : IRequestHandler<GetMyChatGroupQueryRequest, GetMyChatGroupQueryResponse>
    {
        IChatMemberReadRepository _chatMemberReadRepository;
        IChatReadRepository _chatReadRepository;
        IMessageReadRepository _messageReadRepository;

        public GetMyChatGroupQueryHandler(IChatMemberReadRepository chatMemberReadRepository, IChatReadRepository chatReadRepository, IMessageReadRepository messageReadRepository)
        {
            _chatMemberReadRepository = chatMemberReadRepository;
            _chatReadRepository = chatReadRepository;
            _messageReadRepository = messageReadRepository;
        }

        public async Task<GetMyChatGroupQueryResponse> Handle(GetMyChatGroupQueryRequest request, CancellationToken cancellationToken)
        {
            var chatsId = _chatMemberReadRepository.GetWhere(x => x.AppUserId == request.UserId).Select(x => x.ChatId).ToList();

            var ChatGroupDetailDto = _chatReadRepository.GetWhere(x => chatsId.Contains(x.Id)).ToList();
            
            //Mapper Yapılması Gerekiyor
            //Bu Metoda Direk Refactoing gerekicek

            var result = new List<ChatGroupDetailDtoLeft>();

            foreach (var item in ChatGroupDetailDto)
            {
                string lastMessage="";
                string lastMessageDate="";

                var res1 = _messageReadRepository.GetWhere(x => x.ChatId == item.Id).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                
                if (res1 != null)
                    lastMessage = res1.MessageContent;

                var res2 = _messageReadRepository.GetWhere(x => x.ChatId == item.Id).OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                if (res2 != null)
                    lastMessageDate = res2.CreatedDate.ToString();


                ChatGroupDetailDtoLeft add = new ChatGroupDetailDtoLeft()
                {
                    Id = item.Id.ToString(),
                    ChatDescription = item.ChatDescription,
                    ChatName = item.ChatName,
                    ChatPhoto = item.ChatPhoto,
                    LastMessage = lastMessage,
                    LastMessageDate = lastMessageDate
                };
                result.Add(add);
            }
            return  new GetMyChatGroupQueryResponse { ChatGroupDetails = result };
        }
    }
}
