using NeedForCars.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Model : IIdentifiable
    {
        public int Id { get; set; }


        [Required]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ModelEngines> ModelEngines { get; set; }


        public int? Seats { get; set; }

        //TODO : Remaining Model properties
    }
}
