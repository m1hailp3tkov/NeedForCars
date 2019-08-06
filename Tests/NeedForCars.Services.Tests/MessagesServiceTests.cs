using Microsoft.EntityFrameworkCore;
using NeedForCars.Data;
using NeedForCars.Models;
using System.Threading.Tasks;
using Xunit;

namespace NeedForCars.Services.Tests
{
    public class MessagesServiceTests
    {
        [Fact]
        public async Task GetByIdReturnsCorrectMessage()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetByIdMessageDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content"
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            var result = messagesService.GetById(message.Id);

            Assert.Equal(sender.Id, result.SenderId);
        }

        [Fact]
        public async Task GetAllReceivedReturnsCorrectMessages()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllReceivedMessageDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message1 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content"
            };
            var message2 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content2"
            };

            await context.Messages.AddAsync(message1);
            await context.Messages.AddAsync(message2);
            await context.SaveChangesAsync();

            var result = await messagesService.GetAllReceivedForUser(receiver.Id).CountAsync();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetAllSentReturnsCorrectMessages()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllSentMessageDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message1 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content"
            };
            var message2 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content2"
            };

            await context.Messages.AddAsync(message1);
            await context.Messages.AddAsync(message2);
            await context.SaveChangesAsync();

            var result = await messagesService.GetAllSentForUser(sender.Id).CountAsync();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetAllUnreadReturnsCorrectMessages()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("GetAllUnreadMessagesDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message1 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content",
                Read = true
            };
            var message2 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content2",
                Read = false
            };

            await context.Messages.AddAsync(message1);
            await context.Messages.AddAsync(message2);
            await context.SaveChangesAsync();

            var result = await messagesService.GetAllUnreadForUser(receiver.Id).CountAsync();

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task MarkAsReadMarksMessageAsRead()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("MarkAsReadMessagesDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content",
                Read = false
            };

            await context.Messages.AddAsync(message);
            await context.SaveChangesAsync();

            await messagesService.MarkAsRead(message);

            var result = await context.Messages.FirstAsync();

            Assert.True(result.Read);
        }

        [Fact]
        public async Task SendMessageSendsMessageCorrectly()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("SendMessageDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            await messagesService.SendMessageAsync(sender.Id, receiver.Id, "some message");

            var result = await context.Messages.FirstAsync();

            Assert.True(result.SenderId == sender.Id && result.ReceiverId == receiver.Id && result.Content == "some message");
        }

        [Fact]
        public async Task HasUnreadReturnsCorrectValue()
        {
            var options = new DbContextOptionsBuilder<NeedForCarsDbContext>()
                .UseInMemoryDatabase("HasUnreadMessageDb")
                .Options;

            var context = new NeedForCarsDbContext(options);

            var messagesService = new MessagesService(context);

            var sender = new NeedForCarsUser
            {
                Email = "email@mail.com",
                UserName = "username",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567890"
            };
            var receiver = new NeedForCarsUser
            {
                Email = "email2@mail.com",
                UserName = "username2",
                PasswordHash = "HASHEDPASSWORD",
                FirstName = "First",
                LastName = "Last",
                PhoneNumber = "1234567899"
            };

            await context.Users.AddAsync(sender);
            await context.Users.AddAsync(receiver);
            await context.SaveChangesAsync();

            var message1 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content",
                Read = false
            };

            var message2 = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Content = "content",
                Read = true
            };

            await context.Messages.AddAsync(message1);
            await context.Messages.AddAsync(message2);
            await context.SaveChangesAsync();

            var result = messagesService.HasUnreadMessages(receiver.Id);

            Assert.True(result);
        }
    }
}
