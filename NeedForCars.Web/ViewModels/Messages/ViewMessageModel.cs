using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Messages
{
    public class ViewMessageModel : IMapFrom<Message>
    {
        public string Id { get; set; }

        public NeedForCarsUser Sender { get; set; }

        public NeedForCarsUser Receiver { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }
    }
}
