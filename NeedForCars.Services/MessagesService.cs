using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;

namespace NeedForCars.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly NeedForCarsDbContext context;

        public MessagesService(NeedForCarsDbContext context)
        {
            this.context = context;
        }

        public Message GetById(string id)
        {
            var message = this.context.Messages
                .Include(x => x.Receiver)
                .Include(x => x.Sender)
                .FirstOrDefault(x => x.Id == id);

            return message;
        }

        public IQueryable<Message> GetAllReceivedForUser(string userId)
        {
            var messages = this.context.Messages
                .Where(x => x.ReceiverId == userId)
                .Include(x => x.Sender)
                .Include(x => x.Receiver);

            return messages;
        }

        public IQueryable<Message> GetAllSentForUser(string userId)
        {
            var messages = this.context.Messages
                .Where(x => x.SenderId == userId)
                .Include(x => x.Sender)
                .Include(x => x.Receiver);

            return messages;
        }

        public IQueryable<Message> GetAllUnreadForUser(string userId)
        {
            var messages = this.context.Messages
                .Include(x => x.Receiver)
                .Include(x => x.Sender)
                .Where(x => x.ReceiverId == userId)
                .Where(x => !x.Read);

            return messages;
        }

        public async Task MarkAsRead(Message message)
        {
            message.Read = true;

            this.context.Messages.Update(message);

            await this.context.SaveChangesAsync();
        }

        public async Task MarkAsRead(string messageId)
        {
            var message = this.GetById(messageId);

            message.Read = true;

            this.context.Messages.Update(message);

            await this.context.SaveChangesAsync();
        }

        public async Task SendMessageAsync(string senderId, string receiverId, string content)
        {
            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = content
            };

            this.context.Messages.Add(message);

            await this.context.SaveChangesAsync();
        }

        public bool HasUnreadMessages(string userId)
        {
            return this.context.Messages
                .Where(x => x.ReceiverId == userId)
                .Any(x => !x.Read);
        }
    }
}
