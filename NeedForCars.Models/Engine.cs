using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Engine : IIdentifiable
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int MaxHP { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        public ICollection<ModelEngines> ModelEngines { get; set; }


        public string Description { get; set; }

        public int? Displacement { get; set; }

        //TODO: Remaining engine properties
    }
}
