using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {

        IFriendRepository friendRepository;
        IUserRepository userRepository;
        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        public IEnumerable<Friend> GetFriendsByUserId(int recipientId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.user_id);
                var recipientUserEntity = userRepository.FindById(m.friend_id);

                friends.Add(new Friend(m.id, senderUserEntity.email, recipientUserEntity.email, recipientUserEntity.lastname, recipientUserEntity.firstname));
            });

            return friends;
        }
     

        public void AddFriend(FriendSendingData friendSendingData)
        {


            var findUserEntity = this.userRepository.FindByEmail(friendSendingData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();


            var friendEntity = new FriendEntity()
            {
                user_id = friendSendingData.SenderId,
                friend_id = findUserEntity.id
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();

        }
    }
}
