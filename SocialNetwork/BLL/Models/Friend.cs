using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int Id { get; }
        public string SenderEmail { get; }
        public string RecipientEmail { get; }
        public string Name { get; }
        public string LastName { get; }


        public Friend(int id, string senderEmail, string recipientEmail, string name, string lastName )
        {
            this.Id = id;
            this.SenderEmail = senderEmail;
            this.RecipientEmail = recipientEmail;
            this.Name = name;
            this.LastName = lastName;
        }

    }
}
