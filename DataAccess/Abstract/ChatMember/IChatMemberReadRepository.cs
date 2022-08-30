using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.ChatMember
{
    public interface IChatMemberReadRepository :IReadRepository<Entities.Abstract.ChatMember>
    {
    }
}
