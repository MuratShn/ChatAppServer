using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Commands.Message.AddMessage
{
    public class AddMessageCommandResponse
    {
        public bool isSucceded { get; set; }
        public string Message { get; set; }
    }
}
