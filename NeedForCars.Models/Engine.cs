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
        }

        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        [RegularExpression("[A-Za-z, ]+")]
        public string Creator { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int MaxHP { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        //Nullables
        public string Description { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxHPAtRpm { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxTorque { get; set; }

        [Range(1, int.MaxValue)]
        public int? MaxTorqueAtRpm { get; set; }

        public Aspiration? Aspiration { get; set; }

        [Range(1, int.MaxValue)]
        public int? Displacement { get; set; }

        [Range(1, int.MaxValue)]
        public int? NumberOfCylinders { get; set; }

        public EngineConfiguration? EngineConfiguration { get; set; }

        [Range(typeof(decimal), "0.1M", "1000M")]
        public decimal? CylinderBore { get; set; }

        [Range(typeof(decimal), "0.1M", "1000M")]
        public decimal? PistonStroke { get; set; }

        [Range(2, 6)]
        public int? ValvesPerCylinder { get; set; }

        public Valvetrain? ValvetrainType { get; set; }
    }
}
