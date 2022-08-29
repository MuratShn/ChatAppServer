using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class Message : BaseEntity
    {
        public string? SenderUserId { get; set; }
        public string? ChatId { get; set; }
        public string? MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
