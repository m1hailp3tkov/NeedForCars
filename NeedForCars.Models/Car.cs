﻿using NeedForCars.Models.Contracts;
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

        //Nullables
        [RegularExpression(@"[A-Za-z0-9 ,\/-]+")] //TODO: extract modification name regex to globals
        public string Name { get; set; }

        //Performance Data
        [Range(1, 500)]
        public int? TopSpeed { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        public DriveWheel? DriveWheel { get; set; }

        public Transmission? Transmission { get; set; }

        [Range(1, 10)]
        public int? NumberOfGears { get; set; }

        //Production Data
        //TODO Server Validation for production DateTimes in CarModel
        public DateTime? BeginningOfProduction { get; set; }

        public DateTime? EndOfProduction { get; set; }

        //Body/physical data
        public BodyType BodyType { get; set; }

        [Range(1, 8)]
        public int? Seats { get; set; }

        // TODO: Server Validations for wheel sizes: 
        /*
         * 135-315
         * 30-80
         * 12-22
        */
        [RegularExpression(@"\d{3}\/\d{2} R\d{2}")]
        public string TiresSize { get; set; }

        //Safety data

        public bool? HasABS { get; set; }

        public bool? HasESP { get; set; }

        public bool? HasTSC { get; set; }
    }
}