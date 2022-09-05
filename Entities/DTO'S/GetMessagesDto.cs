using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class GetMessagesDto
    {
        public string SenderUserName { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageTime { get; set; }

    }
}
