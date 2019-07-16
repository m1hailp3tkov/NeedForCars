using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Engines
{
    public class CreateEngineModel : IMapTo<Engine>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(FuelType))]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(1, 3000)]
        public int MaxHP { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        public string Description { get; set; }

        [RegularExpression(@"[A-Za-z.\-, ]+")]
        public string Creator { get; set; }

        [Url]
        public string CreatorInfoUrl { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxHPAtRpm { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxTorque { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxTorqueAtRpm { get; set; }

        public Aspiration? Aspiration { get; set; }

        [Range(1, 28400)]
        public int? Displacement { get; set; }

        [Range(1, 18)]
        public int? NumberOfCylinders { get; set; }

        public EngineConfiguration? EngineConfiguration { get; set; }

        [Range(typeof(decimal), "0.1", "1000")]
        public decimal? CylinderBore { get; set; }

        [Range(typeof(decimal), "0.1", "1000")]
        public decimal? PistonStroke { get; set; }

        [Range(2, 6)]
        public int? ValvesPerCylinder { get; set; }

        public Valvetrain? ValvetrainType { get; set; }
    }
}
