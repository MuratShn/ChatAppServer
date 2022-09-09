using Business.Features.Commands.Message.AddMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IChatHubService
    {
        public  Task SendMessage(AddMessageCommandRequest request);
    }
}
