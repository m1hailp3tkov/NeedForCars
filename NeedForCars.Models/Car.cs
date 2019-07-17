using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Car : IIdentifiable
    {
        public string Id { get; set; }

        [Required]
        public string GenerationId { get; set; }
        public Generation Generation { get; set; }

        [Required]
        public string EngineId { get; set; }
        public Engine Engine { get; set; }

        [Required]
        public Transmission Transmission { get; set; }

        [Required]
        public DriveWheel DriveWheel { get; set; }


        //Nullables
        public string Name { get; set; }

        //Performance Data
        [Range(1, 500)]
        public int? TopSpeed { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        [Range(1, 10)]
        public int? NumberOfGears { get; set; }

        //Production Data
        //TODO Server Validation for production DateTimes in CarModel
        public DateTime? BeginningOfProduction { get; set; }

        public DateTime? EndOfProduction { get; set; }

        // TODO: Server Validations for wheel sizes: 
        /*
         * 135-315
         * 30-80
         * 12-22
        */
        public string TiresSize { get; set; }

        //Safety data

        public bool? HasABS { get; set; }

        public bool? HasESP { get; set; }

        public bool? HasTSC { get; set; }
    }
}