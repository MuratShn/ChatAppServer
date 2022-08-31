using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ClientId { get; set; }
        public string? RefreshToken { get; set; }

        //public string Description { get; set; } //Durum ıcın
        //public string Photo { get; set; } //bunlar eklenıcek

        //public ICollection<Chat> Chats { get; set; }
        //public ICollection<ChatMember> ChatMembers { get; set; }
        //public ICollection<Message> Messages { get; set; } 

        //mimarisine sokim
    }
}
