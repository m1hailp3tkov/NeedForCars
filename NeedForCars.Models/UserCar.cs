using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class UserCar : IIdentifiable<string>
    {
        public UserCar()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        [Required]
        public string OwnerId { get; set; }
        public NeedForCarsUser Owner { get; set; }

        [Required]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [Required]
        //TODO Model validation for color
        public string Color { get; set; }

        [Required]
        public int ProductionDateYear { get; set; }
        public int ProductionDateMonth { get; set; }

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

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public int? CustomMaxHP { get; set; }

        public string PerformanceModificationsDescription { get; set; }

        // Visual
        public string VisualModificationsDescription { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
