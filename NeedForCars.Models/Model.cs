using NeedForCars.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Model : IIdentifiable
    {
        public string Id { get; set; }


        [Required]
        public string MakeId { get; set; }
        public Make Make { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ModelEngines> ModelEngines { get; set; }


        public int? Seats { get; set; }

        //TODO : Remaining Model properties
    }
}
