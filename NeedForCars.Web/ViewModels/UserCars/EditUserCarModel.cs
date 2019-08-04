using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using System.Collections.Generic;

namespace NeedForCars.Web.ViewModels.UserCars
{
    public class EditUserCarModel : IMapFrom<UserCar>, IMapTo<UserCar>
    {
        public string Id { get; set; }

        public IEnumerable<IFormFile> Photos { get; set; }

        public string Color { get; set; }

        public int Mileage { get; set; }

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public AlternativeFuel AlternativeFuel { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public bool IsPerformanceModified { get; set; }

        public bool IsVisuallyModified { get; set; }

        public int? Price { get; set; }

        public Currency Currency { get; set; }

        public int? CustomMaxHP { get; set; }

        public string Description { get; set; }

        public string PerformanceModificationsDescription { get; set; }

        public string VisualModificationsDescription { get; set; }

    }
}
