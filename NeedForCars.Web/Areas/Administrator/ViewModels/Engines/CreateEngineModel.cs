using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Engines
{
    public class CreateEngineModel : IMapTo<Engine>
    {
        [Required(ErrorMessage = GlobalConstants.REQUIRED_NAME)]
        [RegularExpression(GlobalConstants.ENGINE_NAME_REGEX, ErrorMessage = GlobalConstants.ENGINE_NAME_INVALID)]
        public string Name { get; set; }

        [EnumDataType(typeof(FuelType), ErrorMessage = GlobalConstants.FUELTYPE_INVALID)]
        [DisplayName("Fuel Type")]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(1, 3000, ErrorMessage = GlobalConstants.ENGINE_NUMBERVALUE_INVALID)]
        [DisplayName("Max Horsepower")]
        public int MaxHP { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.ENGINE_CREATOR_REGEX, ErrorMessage = GlobalConstants.ENGINE_CREATOR_INVALID)]
        public string Creator { get; set; }

        [Url]
        [DisplayName("Creator Info (url)")]
        public string CreatorInfoUrl { get; set; }

        public string Description { get; set; }

        [DisplayName("Alternative Fuel")]
        public AlternativeFuel? AlternativeFuel { get; set; }

        [Range(1, 20000)]
        [DisplayName("Max HP @ RPM")]
        public int? MaxHPAtRpm { get; set; }

        [Range(1, 20000)]
        [DisplayName("Max Torque")]
        public int? MaxTorque { get; set; }

        [Range(0, 20000)]
        [DisplayName("Max Torque @ RPM")]
        public int? MaxTorqueAtRpm { get; set; }

        public Aspiration? Aspiration { get; set; }

        [Range(1, 28400)]
        public int? Displacement { get; set; }

        [Range(1, 18, ErrorMessage = GlobalConstants.ENGINE_NUMBEROFCYLINDERS_INVALID)]
        [DisplayName("Number of Cylinders")]
        public int? NumberOfCylinders { get; set; }

        [DisplayName("Configuration")]
        public EngineConfiguration? EngineConfiguration { get; set; }

        [Range(typeof(decimal), "0.1", "1000")]
        [DisplayName("Cylinder Bore (mm)")]
        public decimal? CylinderBore { get; set; }

        [Range(typeof(decimal), "0.1", "1000")]
        [DisplayName("Piston Stroke (mm)")]
        public decimal? PistonStroke { get; set; }

        [Range(2, 6, ErrorMessage = GlobalConstants.ENGINE_VALVESPERCYLINDER_INVALID)]
        [DisplayName("Valves per Cylinder")]
        public int? ValvesPerCylinder { get; set; }

        [DisplayName("Valvetrain")]
        public Valvetrain? ValvetrainType { get; set; }
    }
}
