using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class UpdateChatGroupDto 
    {
        public string ChatId { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }

    }
}
