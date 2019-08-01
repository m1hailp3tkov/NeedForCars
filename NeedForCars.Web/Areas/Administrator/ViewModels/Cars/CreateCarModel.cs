using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class CreateCarModel : IMapTo<Car>
    {
        [Required]
        [DisplayName("Engine")]
        public int EngineId { get; set; }

        [Required]
        [EnumDataType(typeof(Transmission))]
        public Transmission Transmission { get; set; }

        [Required]
        [DisplayName("Drive Wheel")]
        [EnumDataType(typeof(DriveWheel))]
        public DriveWheel DriveWheel { get; set; }

        //Datetime properties:
        [Required]
        //TODO: Validation attribute for beginning
        public int BeginningOfProductionYear { get; set; }
        [Required]
        [Range(1,12)]
        public int BeginningOfProductionMonth { get; set; }

        [Range(1879, int.MaxValue)]
        public int? EndOfProductionYear { get; set; }
        [Range(1,12)]
        public int? EndOfProductionMonth { get; set; }

        //Safety data
        [Required]
        [DisplayName("ABS")]
        public bool HasABS { get; set; }

        [Required]
        [DisplayName("ESP")]
        public bool HasESP { get; set; }

        [Required]
        [DisplayName("TCS")]
        public bool HasTCS { get; set; }

        //Nullables
        public string Name { get; set; }

        //Performance Data
        [Range(1, 500, ErrorMessage = GlobalConstants.CAR_TOPSPEED_INVALID)]
        [DisplayName("Top Speed (km/h)")]
        public int? TopSpeed { get; set; }

        [Range(1, 10, ErrorMessage = GlobalConstants.CAR_NUMBEROFGEARS_INVALID)]
        [DisplayName("Number of Gears")]
        public int? NumberOfGears { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        public TireInfo TireInfo { get; set; }
    }
}
