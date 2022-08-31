using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class Message : BaseEntity
    {
        [ForeignKey(nameof(AppUser))]
        public string? SenderUserId { get; set; }
        public Guid? ChatId { get; set; }
        public string? MessageContent { get; set; }

        public AppUser AppUser { get; set; }
        public Chat Chat { get; set; }
    }
}
