using Core.Entities;
using Entities.Abstract.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public class Chat : BaseEntity
    {
        //Özel Ve Group konuşmaları ayrılmadan bu tabloda tutulucak birberi konusmalarda Chat açıklaması vs olmadıgı ıcın null olabilir
        public string? ChatName { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string? CreatedUserId { get; set; }
        public string? ChatDescription { get; set; }
        public string? ChatPhoto { get; set; }
        //public string? ChatMembersId { get; set; }


        public AppUser AppUser { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
