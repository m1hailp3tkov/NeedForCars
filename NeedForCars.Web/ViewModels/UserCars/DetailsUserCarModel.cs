using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.UserCars
{
    public class DetailsUserCarModel : IMapFrom<UserCar>
    {
        public string Id { get; set; }

        public string OwnerId { get; set; }
        public string OwnerUserName { get; set; }

        public int CarId { get; set; }

        public string Color { get; set; }

        public int ProductionDateYear { get; set; }
        public int ProductionDateMonth { get; set; }

        public int Mileage { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public string Description { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        public int? CustomMaxHP { get; set; }

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }
    }
}
