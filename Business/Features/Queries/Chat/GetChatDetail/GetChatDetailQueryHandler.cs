using Core.Entities;
using DataAccess.Abstract.Chat;
using DataAccess.Abstract.ChatMember;
using Entities.DTO_S;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.GetChatDetail
{
    public class GetChatDetailQueryHandler : IRequestHandler<GetChatDetailQueryRequest, GetChatDetailQueryResponse>
    {
        private readonly IChatReadRepository _chatReadRepository;
        private readonly IChatMemberReadRepository _chatMemberReadRepository;
        private readonly UserManager<AppUser> _userManager;
        public GetChatDetailQueryHandler(IChatReadRepository chatReadRepository, IChatMemberReadRepository chatMemberReadRepository, UserManager<AppUser> userManager)
        {
            _chatReadRepository = chatReadRepository;
            _chatMemberReadRepository = chatMemberReadRepository;
            _userManager = userManager;
        }

        public async Task<GetChatDetailQueryResponse> Handle(GetChatDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var chat = await _chatReadRepository.GetByIdAsync(request.Id);
            
            var usersId = _chatMemberReadRepository.GetWhere(x => x.ChatId == Guid.Parse(request.Id)).Select(x=>x.AppUserId).ToList();
            
            if (usersId.Count()>2) 
            {
                var users = _userManager.Users.Where(x => usersId.Contains(x.Id)).ToList();
                var createdUser = await _userManager.FindByIdAsync(chat.CreatedUserId);
                
                var usersInfo = new List<UserGroupDetailDto>();
                foreach (var item in users)
                {
                    var userInfo = new UserGroupDetailDto() //user photo ve description eklenıcek bu dto'ya
                    {
                        UserName = item.UserName,
                    };
                    usersInfo.Add(userInfo);
                }
                return new()
                {
                    ChatType="Group",
                    ChatDescription = chat.ChatDescription,
                    ChatName = chat.ChatName,
                    ChatPhoto = chat.ChatPhoto,
                    CreatedUser = createdUser.UserName,
                  
                    UsersDetail = usersInfo
                };


            }

            else
            {
                //grup olusturulduktan sonra cıkanlar olabılır ondan dolayı bir kontrol daha yapmak gerekir
                if (chat.ChatName == null)
                {

                    var anotherUserId = usersId.Where(x => x != request.Id).FirstOrDefault();
                    var anotherUser = await _userManager.FindByIdAsync(anotherUserId);
                    return new()
                    {
                        ChatType = "Single",
                        ChatName = anotherUser.UserName,
                        //ChatPhoto = anotherUser.Photo,
                        //ChatDescription = anotherUser.Description
                    };
                }

                else
                {
                    //bu kısımda grup olarak kurulmus fakat 2 kısıden az kısı kalmış
                    //Databasede grupmu singlemı alanını tutsak cok rahat ederız

                    var users = _userManager.Users.Where(x => usersId.Contains(x.Id)).ToList();
                    var createdUser = await _userManager.FindByIdAsync(chat.CreatedUserId); //bu kodları gene yazdım aq
                    var usersInfo = new List<UserGroupDetailDto>();


                    foreach (var item in users)
                    {
                        var userInfo = new UserGroupDetailDto() //user photo ve description eklenıcek bu dto'ya
                        {
                            UserName = item.UserName,
                        };
                        usersInfo.Add(userInfo);
                    }

                    return new()
                    {
                        ChatType = "Group",
                        ChatDescription = chat.ChatDescription,
                        ChatName = chat.ChatName,
                        ChatPhoto = chat.ChatPhoto,
                        CreatedUser = createdUser.UserName,

                        UsersDetail = usersInfo
                    };
                }

            }

            throw new NotImplementedException();
        }
    }
}
