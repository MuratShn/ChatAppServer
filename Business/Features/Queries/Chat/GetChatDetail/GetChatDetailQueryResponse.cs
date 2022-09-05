using Core.Entities;
using Entities.DTO_S;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Queries.Chat.GetChatDetail
{
    public class GetChatDetailQueryResponse
    {
        public string? ChatType { get; set; } //bunu database tarafındada yapmak lazım aslında
        public string? ChatName { get; set; }
        public string? CreatedUser { get; set; }
        public string? ChatDescription { get; set; }
        public string? ChatPhoto { get; set; }
        public List<UserGroupDetailDto>? UsersDetail { get; set; } 
    }
}
