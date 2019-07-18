using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class CreateCarModel : IMapTo<Car>
    {
        [Required]
        public string EngineId { get; set; }

        [Required]
        [EnumDataType(typeof(Transmission))]
        public Transmission Transmission { get; set; }

        [Required]
        [EnumDataType(typeof(DriveWheel))]
        public DriveWheel DriveWheel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BeginningOfProduction { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndOfProduction { get; set; }

        //Nullables
        public string Name { get; set; }

        //Performance Data
        [Range(1, 500, ErrorMessage = "{0} must be a value between {1} and {2}")]
        public int? TopSpeed { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        [Range(1, 10)]
        public int? NumberOfGears { get; set; }



        //TODO: Extract regex to global constants
        [RegularExpression(@"\d{3}\/\d{2}\/R\d{2}", ErrorMessage = "Invalid tire size")]
        public string TiresSize { get => $"{TireWidth}/{AspectRatio}/R{WheelDiameter}"; }

        [Range(135, 315, ErrorMessage = "Invalid tire width")]
        public int TireWidth { get; set; }
        [Range(30, 80, ErrorMessage = "Invalid tire aspect ratio")]
        public int AspectRatio { get; set; }
        [Range(12, 22, ErrorMessage = "Invalid wheel diameter")]
        public int WheelDiameter { get; set; }

        //Safety data
        public bool? HasABS { get; set; }

        public bool? HasESP { get; set; }

        public bool? HasTSC { get; set; }
    }
}
