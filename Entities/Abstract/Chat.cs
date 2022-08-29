using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class Chat : BaseEntity
    {
        //Özel Ve Group konuşmaları ayrılmadan bu tabloda tutulucak birberi konusmalarda Chat açıklaması vs olmadıgı ıcın null olabilir
        public string? ChatName { get; set; }
        public string? CreatedUserId { get; set; }
        public string? ChatDescription { get; set; }
        public string? ChatPhoto { get; set; }
        public DateTime? ChatCreatedDate { get; set; }
        public string? ChatMembersId { get; set; }

    }
}
