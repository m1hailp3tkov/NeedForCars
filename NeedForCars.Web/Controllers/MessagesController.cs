using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeedForCars.Models;
using NeedForCars.Services.Contracts;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using NeedForCars.Web.ViewModels.Messages;
using X.PagedList;

namespace NeedForCars.Web.Controllers
{
    public class MessagesController : UserController
    {
        private readonly IMessagesService messagesService;
        private readonly UserManager<NeedForCarsUser> userManager;

        public MessagesController(IMessagesService messagesService, UserManager<NeedForCarsUser> userManager)
        {
            this.messagesService = messagesService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.RedirectToAction(nameof(Unread));
        }

        public IActionResult Unread(int? page)
        {
            var userId = this.userManager.GetUserId(this.User);

            int pageNumber = (page ?? 1);

            var messages = this.messagesService.GetAllUnreadForUser(userId)
                .To<ViewMessageModel>()
                .OrderByDescending(x => x.SentOn)
                .ToPagedList(pageNumber, 10);

            return View(messages);
        }
        
        public IActionResult Sent(int? page)
        {
            var userId = this.userManager.GetUserId(this.User);

            int pageNumber = (page ?? 1);

            var messages = this.messagesService.GetAllSentForUser(userId)
                .To<ViewMessageModel>()
                .OrderByDescending(x => x.SentOn)
                .ToPagedList(pageNumber, 10);

            return this.View(messages);
        }

        public IActionResult Received(int? page)
        {
            var userId = this.userManager.GetUserId(this.User);

            int pageNumber = (page ?? 1);

            var messages = this.messagesService.GetAllReceivedForUser(userId)
                .To<ViewMessageModel>()
                .OrderByDescending(x => x.SentOn)
                .ToPagedList(pageNumber, 10);

            return this.View(messages);
        }

        public IActionResult SendMessage(string receiver)
        {
            var viewModel = new SendMessageModel { Receiver = receiver };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageModel sendMessageModel)
        {
            var senderId = this.userManager.GetUserId(this.User);
            var receiver = await this.userManager.FindByNameAsync(sendMessageModel.Receiver);

            if (receiver == null)
            {
                this.ModelState.AddModelError(nameof(sendMessageModel.Receiver), GlobalConstants.MESSAGE_RECEIVER_INVALID);
            }

            if(!ModelState.IsValid)
            {
                return this.View(sendMessageModel);
            }

            await messagesService.SendMessageAsync(senderId, receiver.Id, sendMessageModel.Content);

            return this.RedirectToAction(nameof(Sent));
        }

        public IActionResult ViewMessage(string id)
        {
            var message = this.messagesService.GetById(id);
            var userId = this.userManager.GetUserId(this.User);

            if(message == null)
            {
                return this.BadRequest();
            }

            if (userId != message.ReceiverId)
            {
                return this.Forbid();
            }

            var viewModel = Mapper.Map<ViewMessageModel>(message);

            messagesService.MarkAsRead(id);

            return this.View(viewModel);
        }
    }
}