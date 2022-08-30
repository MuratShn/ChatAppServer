using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Chat
{
    public interface IChatReadRepository : IReadRepository<Entities.Abstract.Chat>
    {
    }
}
