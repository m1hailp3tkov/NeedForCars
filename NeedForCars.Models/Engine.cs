using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Engine : IIdentifiable
    {
        public Engine()
        {
            this.Cars = new HashSet<Car>();
            this.ModifiedCars = new HashSet<UserCar>();
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MaxHP { get; set; }

        [Required]
        public string Creator { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<UserCar> ModifiedCars { get; set; }

        //Nullables
        public string CreatorInfoUrl { get; set; }

        public AlternativeFuel? AlternativeFuel { get; set; }

        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxHPAtRpm { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxTorque { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxTorqueAtRpm { get; set; }

        [EnumDataType(typeof(Aspiration))]
        public Aspiration? Aspiration { get; set; }

        [Range(1, int.MaxValue)]
        public int? Displacement { get; set; }

        [Range(1, int.MaxValue)]
        public int? NumberOfCylinders { get; set; }

        public EngineConfiguration? EngineConfiguration { get; set; }

        public decimal? CylinderBore { get; set; }

        public decimal? PistonStroke { get; set; }

        public int? ValvesPerCylinder { get; set; }

        public Valvetrain? ValvetrainType { get; set; }
    }
}
