﻿using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Model : IIdentifiable<int>
    {
        public Model()
        {
            this.Generations = new HashSet<Generation>();
        }

        public int Id { get; set; }

        [Required]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Generation> Generations { get; set; }

        //Nullables
        public string Description { get; set; }
    }
}
