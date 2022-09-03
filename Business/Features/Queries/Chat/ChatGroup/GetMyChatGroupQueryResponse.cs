using Entities.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.ChatGroup
{
    public class GetMyChatGroupQueryResponse
    {
        public List<ChatGroupDetailDtoLeft> ChatGroupDetails { get; set; }
    }
}
