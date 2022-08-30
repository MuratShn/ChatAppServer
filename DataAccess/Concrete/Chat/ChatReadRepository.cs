using DataAccess.Abstract.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Chat
{
    public class ChatReadRepository : ReadRepository<Entities.Abstract.Chat>, IChatReadRepository
    {
        public ChatReadRepository(Context context) : base(context)
        {
        }
    }
}
