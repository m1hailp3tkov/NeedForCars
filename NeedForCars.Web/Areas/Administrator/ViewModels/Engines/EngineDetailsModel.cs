using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Engines
{
    public class EngineDetailsModel : IMapFrom<Engine>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public FuelType FuelType { get; set; }

        public int MaxHP { get; set; }

        //Nullables
        public AlternativeFuel? AlternativeFuel { get; set; }

        public string Description { get; set; }

        public string Creator { get; set; }

        public string CreatorInfoUrl { get; set; }

        public int? MaxHPAtRpm { get; set; }

        public int? MaxTorque { get; set; }

        public int? MaxTorqueAtRpm { get; set; }

        public Aspiration? Aspiration { get; set; }

        public int? Displacement { get; set; }

        public int? NumberOfCylinders { get; set; }

        public EngineConfiguration? EngineConfiguration { get; set; }

        public decimal? CylinderBore { get; set; }

        public decimal? PistonStroke { get; set; }

        public int? ValvesPerCylinder { get; set; }

        public Valvetrain? ValvetrainType { get; set; }
    }
}
