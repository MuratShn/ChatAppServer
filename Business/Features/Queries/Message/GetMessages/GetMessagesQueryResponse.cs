using Entities.DTO_S;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Message.GetMessages
{
    public class GetMessagesQueryResponse 
    {
        public string MyUserName { get; set; }
        public List<GetMessagesDto> Messages { get; set; }
    }
}
