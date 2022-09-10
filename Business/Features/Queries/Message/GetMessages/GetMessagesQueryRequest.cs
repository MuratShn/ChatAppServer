using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Message.GetMessages
{
    public class GetMessagesQueryRequest : IRequest<GetMessagesQueryResponse>
    {
        public string ChatId { get; set; }
        public string? MyUserId { get; set; }
        public int Page { get; set; } = 0;

    }
}
