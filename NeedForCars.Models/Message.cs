using NeedForCars.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Message : IIdentifiable<string>
    {
        public string Id { get; set; }

        public Message()
        {
            this.Read = false;

            this.SentOn = DateTime.UtcNow;
        }


        [Required]
        public string SenderId { get; set; }
        public NeedForCarsUser Sender { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        public NeedForCarsUser Receiver { get; set; }

        //TODO Message content string length server validation
        [Required]
        [MaxLength(1000, ErrorMessage = "Message too long.")]
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public bool Read { get; set; }
    }
}
