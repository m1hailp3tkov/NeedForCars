using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.UserCars
{
    public class CreateUserCarModel : IMapTo<UserCar>
    {
        public string OwnerId { get; set; }

        [Required(ErrorMessage = GlobalConstants.USERCAR_PHOTOS_REQUIRED)]
        public IEnumerable<IFormFile> Photos { get; set; }

        [Required(ErrorMessage = GlobalConstants.USERCAR_CARID_REQUIRED)]
        public int CarId { get; set; }

        [Required(ErrorMessage = GlobalConstants.USERCAR_COLOR_REQUIRED)]
        public string Color { get; set; }

        [Required(ErrorMessage = GlobalConstants.USERCAR_PRODUCTIONDATE_REQUIRED)]
        public DateTime ProductionDate { get; set; }

        [Required(ErrorMessage = GlobalConstants.USERCAR_MILEAGE_REQUIRED)]
        [Range(0, 10000000, ErrorMessage = GlobalConstants.USERCAR_MILEAGE_INVALID)]
        public int Mileage { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public bool IsPerformanceModified { get; set; }

        public bool IsVisuallyModified { get; set; }

        //Nullables
        public string Description { get; set; }

        [EnumDataType(typeof(AlternativeFuel))]
        public AlternativeFuel? AlternativeFuel { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = GlobalConstants.USERCAR_PRICE_INVALID)]
        public int? Price { get; set; }

        [EnumDataType(typeof(Currency))]
        public Currency? Currency { get; set; }

        // Modified Cars
        // Performance
        public int? CustomEngineId { get; set; }

        public FuelConsumption ModifiedFuelConsumption { get; set; }

        public Acceleration ModifiedAcceleration { get; set; }

        public string PerformanceModificationsDescription { get; set; }

        // Visual
        public string VisualModificationsDescription { get; set; }
    }
}
