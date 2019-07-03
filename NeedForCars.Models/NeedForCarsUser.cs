using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class NeedForCarsUser : IdentityUser
    {
        [Required]
        [RegularExpression("[a-zA-Zа-яА-Я]{2,}")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("[a-zA-Zа-яА-Я]{2,}|[a-zA-Zа-яА-Я]{1}.")]
        public string LastName { get; set; }
    }
}
