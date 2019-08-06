using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Messages
{
    public class SendMessageModel : IMapTo<Message>
    {
        [Required(ErrorMessage = GlobalConstants.MESSAGE_RECEIVER_REQUIRED)]
        public string Receiver { get; set; }

        [Required(ErrorMessage = GlobalConstants.MESSAGE_CONTENT_REQUIRED)]
        [MaxLength(3000, ErrorMessage = GlobalConstants.MESSAGE_CONTENT_TOO_LONG)]
        public string Content { get; set; }
    }
}
