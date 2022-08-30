using Core.Entities;
using Entities.Abstract.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class ChatMember : BaseEntity
    {
        public Guid? ChatId { get; set; }
        public string? AppUserId { get; set; }

        //public Chat Chat { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }

    }
}
