using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsAddingView
    {
        UserService userService;
        FriendService friendService;
        public FriendsAddingView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public void Show(User user)
        {
            var friendSendingData = new FriendSendingData();

            Console.Write("Введите почтовый адрес получателя: ");
            friendSendingData.RecipientEmail = Console.ReadLine();

            friendSendingData.SenderId = user.Id;

            try
            {
                friendService.AddFriend(friendSendingData);

                SuccessMessage.Show("Друг успешно добавлен!");

                user = userService.FindById(user.Id);
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }

        }
    }
}
