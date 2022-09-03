using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.ChatGroup
{
    public class GetMyChatGroupQueryRequest : IRequest<GetMyChatGroupQueryResponse>
    {
        public string UserId { get; set; }
    }
}
