using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.GetChatDetail
{
    public class GetChatDetailQueryRequest : IRequest<GetChatDetailQueryResponse>
    {
        public string? Id { get; set; }
        public string? MyUserId { get; set; }
    }
}
