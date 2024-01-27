using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class UserMessageData
    {
        public int SenderId { get; set; }
        public string Content { get; set; }
        public string RecipientEmail { get; set; }
    }
}



