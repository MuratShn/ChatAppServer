using DataAccess.Abstract.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Chat
{
    public class ChatWriteRepository : WriteRepository<Entities.Abstract.Chat>, IWriteChatRepository
    {
        public ChatWriteRepository(Context context) : base(context)
        {
        }
    }
}
