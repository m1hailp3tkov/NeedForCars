using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using NeedForCars.Services.Mapping;
using System;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class CarDetailsModel : IMapFrom<Car>
    {
        public string Id { get; set; }

        public string GenerationId { get; set; }
        public Generation Generation { get; set; }

        public string EngineId { get; set; }
        public Engine Engine { get; set; }

        public Transmission Transmission { get; set; }

        public DriveWheel DriveWheel { get; set; }

        public DateTime BeginningOfProduction { get; set; }

        public DateTime EndOfProduction { get; set; }

        public string Name { get; set; }

        public int? TopSpeed { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        public TireInfo TireInfo { get; set; }

        public int? NumberOfGears { get; set; }

        public bool HasABS { get; set; }

        public bool HasESP { get; set; }

        public bool HasTCS { get; set; }
    }
}
