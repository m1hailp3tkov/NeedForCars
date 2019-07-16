using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class UserCar : IIdentifiable
    {
        public UserCar()
        {
            this.IsPublic = false;

            this.ForSale = false;

            this.IsPerformanceModified = false;

            this.IsVisuallyModified = false;
        }


        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public NeedForCarsUser Owner { get; set; }

        [Required]
        public string CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        [Range(0, 10000000)]
        public int Mileage { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public bool IsPerformanceModified { get; set; }

        public bool IsVisuallyModified { get; set; }

        //Nullables
        public string Description { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        [Range(1, int.MaxValue)]
        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        // Modified Cars
        // Performance
        public string CustomEngineId { get; set; }
        public Engine CustomEngine { get; set; }

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public string PerformanceModificationsDescription { get; set; }

        // Visual
        public string VisualModificationsDescription { get; set; }
    }
}
