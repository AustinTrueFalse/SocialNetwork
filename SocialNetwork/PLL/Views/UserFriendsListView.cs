using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsListView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Друзья");


            if (friends.Count() == 0)
            {
                Console.WriteLine("Друзей нет");
                return;
            }

            friends.ToList().ForEach(friend =>
            {
                Console.WriteLine("Фамилия: {0}", friend.LastName);
                Console.WriteLine("Имя: {0}", friend.Name);
                Console.WriteLine("Email: {0}", friend.RecipientEmail);
            });
        }
    }
}
