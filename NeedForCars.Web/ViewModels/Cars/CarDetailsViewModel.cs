using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Cars
{
    public class CarDetailsViewModel : IMapFrom<UserCar>
    {
        public string Id { get; set; }

        public NeedForCarsUser Owner { get; set; }

        public Car Car { get; set; }

        public int ProductionDateYear { get; set; }
        public int ProductionDateMonth { get; set; }

        public int Mileage { get; set; }

        public string Description { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public int? CustomMaxHP { get; set; }

        public string PerformanceModificationsDescription { get; set; }

        public string VisualModificationsDescription { get; set; }
    }
}
