using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO_S
{
    public class ChatGroupDetailDtoLeft
    {
        public string Id { get; set; }
        public string? ChatName { get; set; }
        public string? ChatDescription { get; set; }
        public string? ChatPhoto { get; set; }

        public string LastMessage { get; set; }
        public DateTime LastMessageDate { get; set; }

    }
}
