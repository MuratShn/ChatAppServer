using Core.Entities;
using DataAccess.Abstract.Chat;
using DataAccess.Abstract.ChatMember;
using Entities.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Features.Commands.Chat.AddChat
{
    public class AddChatCommandHandler : IRequestHandler<AddChatCommandRequest, AddChatCommandResponse>
    {
        private readonly IWriteChatRepository _writeChatRepository;
        private readonly IChatMemberWriteRepository _chatMemberWriteRepository;
        private readonly UserManager<AppUser> _userManager;
        public AddChatCommandHandler(IWriteChatRepository writeChatRepository, IChatMemberWriteRepository chatMemberWriteRepository, UserManager<AppUser> userManager)
        {
            _writeChatRepository = writeChatRepository;
            _chatMemberWriteRepository = chatMemberWriteRepository;
            _userManager = userManager;
        }

        public async Task<AddChatCommandResponse> Handle(AddChatCommandRequest request, CancellationToken cancellationToken)
        {
            using (TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled)) //parantez içi async calısma içinmiş
            {
                try
                {
                    var chat = new Entities.Abstract.Chat() { ChatDescription = request.GroupDescription, ChatName = request.GroupName ,CreatedUserId =request.CreateUserId}; //chatin ıd'si lazım
                    await _writeChatRepository.AddAsync(chat);

                    var chatUsers = request.GroupUsers.Split(",");

                    if (chatUsers.Count() >= 2)
                    {
                        var chatMembers = new List<ChatMember>();

                        foreach (var item in chatUsers)
                        {
                            var user = await _userManager.FindByNameAsync(item);

                            if (user == null)
                            {
                                scope.Dispose(); //hata veriyor 
                                return new() { isSucceded = false, Message = "Var Olmayan bir kullanıcı girdiniz" };
                            }

                            chatMembers.Add(new ChatMember() { ChatId = chat.Id, AppUserId = user.Id });
                        }
                        await _chatMemberWriteRepository.AddRangeAsync(chatMembers);
                    }

                    else
                    {
                        scope.Dispose();
                        return new AddChatCommandResponse() { isSucceded = false, Message = "Grupta En Az İki Kişi Olmalı" };
                    }

                    await _writeChatRepository.SaveAsync(); //sade bu yeter galıba
                    scope.Complete();
                    return new AddChatCommandResponse() { isSucceded = true, Message = "Grup Başarıyla Oluşturuldu" };
                }
                catch (Exception e)
                {
                    scope.Dispose();
                    throw e;
                }
            }

            throw new NotImplementedException();
        }
    }
}
