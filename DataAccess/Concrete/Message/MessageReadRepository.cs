using DataAccess.Abstract.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Message
{
    public class MessageReadRepository : ReadRepository<Entities.Abstract.Message>, IMessageReadRepository
    {
        public MessageReadRepository(Context context) : base(context)
        {
        }
    }
}
