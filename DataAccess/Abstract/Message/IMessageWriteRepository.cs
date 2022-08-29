using Core.DataAccess;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Message
{
    public interface IMessageWriteRepository : IWriteRepository<Entities.Abstract.Message>
    {

    }
}
