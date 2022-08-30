using Core.DataAccess;
using DataAccess.Abstract.ChatMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.ChatMember
{
    public class ChatMemberWriteRepository :  WriteRepository<Entities.Abstract.ChatMember>, IChatMemberWriteRepository
    {
        public ChatMemberWriteRepository(Context context) : base(context)
        {
        }
    }
}
