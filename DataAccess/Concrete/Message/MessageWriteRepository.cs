using DataAccess.Abstract.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Message
{
    public class MessageWriteRepository : WriteRepository<Entities.Abstract.Message>, IMessageWriteRepository
    {
        public MessageWriteRepository(Context context) : base(context)
        {
        }
    }
}
