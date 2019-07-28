using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Car : IIdentifiable<int>
    {
        public int Id { get; set; }

        [Required]
        public int GenerationId { get; set; }
        public Generation Generation { get; set; }

        [Required]
        public int EngineId { get; set; }
        public Engine Engine { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        [Required]
        public DriveWheel DriveWheel { get; set; }

        [Required]
        public DateTime BeginningOfProduction { get; set; }

        [Required]
        public DateTime EndOfProduction { get; set; }

        //Safety data
        public bool HasABS { get; set; }

        public bool HasESP { get; set; }

        public bool HasTCS { get; set; }

        //Nullables
        public string Name { get; set; }

        //Performance Data
        [Range(1, 500)]
        public int? TopSpeed { get; set; }

        [Range(1, 10)]
        public int? NumberOfGears { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        public TireInfo TireInfo { get; set; }
    }
}