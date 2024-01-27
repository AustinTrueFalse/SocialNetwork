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
    public class MessageService
    {

        IMessageRepository messageRepository;
        IUserRepository userRepository;
        public MessageService()
        {
            userRepository = new UserRepository();
            messageRepository = new MessageRepository();
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipientId)
        {
            var messages = new List<Message>();

            messageRepository.FindByRecipientId(recipientId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int senderId)
        {
            var messages = new List<Message>();

            messageRepository.FindBySenderId(senderId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipientUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipientUserEntity.email));
            });

            return messages;
        }


        public void SendMessage(UserMessageData userMessageData)
        {

            var userRepository = new UserRepository();

            if (String.IsNullOrEmpty(userMessageData.Content))
                throw new ArgumentNullException();

            if (userMessageData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            var findUserEntity = this.userRepository.FindByEmail(userMessageData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            
            var messageEntity = new MessageEntity()
            {
                content = userMessageData.Content,
                sender_id = userMessageData.SenderId,
                recipient_id = findUserEntity.id
            };

            if (this.messageRepository.Create(messageEntity) == 0)
                throw new Exception();


        }

       

        
    }
}
