using Microsoft.AspNetCore.Identity;
using System;

namespace NeedForCars.Models
{
    public class NeedForCarsUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
