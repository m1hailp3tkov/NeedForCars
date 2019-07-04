using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Car : IIdentifiable
    {
        public Car()
        {
            this.IsPublic = false;

            this.ForSale = false;
        }
        

        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public NeedForCarsUser Owner { get; set; }

        [Required]
        public string ModelId { get; set; }
        public Model Model { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public int Mileage { get; set; }


        public string Description { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        //TODO : Implement modifications property (LPG alt fuel, chip tuning, etc)
    }
}
