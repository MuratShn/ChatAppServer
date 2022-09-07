using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Commands.Chat.AddChat
{
    public class AddChatCommandRequest : IRequest<AddChatCommandResponse>
    {
        public string? GroupName { get; set; } //clientta grup yapmısım 
        public string? GroupDescription { get; set; }
        public string? GroupPhoto{ get; set; }
        public string? GroupUsers { get; set; }
        public string? CreateUserId { get; set; }
    }
}
