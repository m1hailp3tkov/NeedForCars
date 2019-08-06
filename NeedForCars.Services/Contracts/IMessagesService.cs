using NeedForCars.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Services.Contracts
{
    public interface IMessagesService
    {
        Message GetById(string id);

        IQueryable<Message> GetAllSentForUser(string userId);

        IQueryable<Message> GetAllReceivedForUser(string userId);

        IQueryable<Message> GetAllUnreadForUser(string userId);

        Task SendMessage(string senderId, string receiverId, string content);

        Task MarkAsRead(string messageId);

        bool HasUnreadMessages(string userId);
    }
}
