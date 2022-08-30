using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Message
{
    public interface IMessageReadRepository : IReadRepository<Entities.Abstract.Message>
    {
        //Eski projedeki gibi ayrı sorguları buraya yazabılırım
    }
}
