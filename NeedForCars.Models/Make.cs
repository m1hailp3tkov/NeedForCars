﻿using NeedForCars.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Make : IIdentifiable<int>
    {
        public Make()
        {
            this.Models = new HashSet<Model>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
