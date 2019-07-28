using Microsoft.AspNetCore.Identity;
using NeedForCars.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class NeedForCarsUser : IdentityUser, IIdentifiable<string>
    {
        public NeedForCarsUser()
        {
            this.UserCars = new HashSet<UserCar>();

            this.SentMessages = new HashSet<Message>();

            this.ReceivedMessages = new HashSet<Message>();
        }


        [Required]
        [PersonalData]
        [RegularExpression("[a-zA-Zа-яА-Я]{2,}")]
        public string FirstName { get; set; }

        [Required]
        [PersonalData]
        [RegularExpression("[a-zA-Zа-яА-Я]{2,}|[a-zA-Zа-яА-Я]{1}.")]
        public string LastName { get; set; }


        public ICollection<UserCar> UserCars { get; set; }

        public ICollection<Message> SentMessages { get; set; }

        public ICollection<Message> ReceivedMessages { get; set; }
    }
}