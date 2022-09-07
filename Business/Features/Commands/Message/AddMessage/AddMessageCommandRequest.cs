using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Commands.Message.AddMessage
{
    public class AddMessageCommandRequest : IRequest<AddMessageCommandResponse>
    {
        public string ChatId { get; set; }
        public string? SenderUserId { get; set; }
        public string Message { get; set; }
    }
}
