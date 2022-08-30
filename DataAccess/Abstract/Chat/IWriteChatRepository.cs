using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Chat
{
 
    //dosya ve entity adı aynı oldugu ıcın yolu vermek zorundayız
    public interface IWriteChatRepository : IWriteRepository<Entities.Abstract.Chat>
    {
    }
}
