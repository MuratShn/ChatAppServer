using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class ChatMember : BaseEntity
    {
        public string? ChatId { get; set; }
        public string? UserId { get; set; }
        public DateTime EntryTime { get; set; } //Kullanıcının giriş zamanı
    }
}
