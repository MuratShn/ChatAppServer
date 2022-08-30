using DataAccess.Abstract.ChatMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ChatMember
{
    public class ChatMemberReadRepository : ReadRepository<Entities.Abstract.ChatMember>,IChatMemberReadRepository
    {
        public ChatMemberReadRepository(Context context) : base(context)
        {
        }
    }
}
