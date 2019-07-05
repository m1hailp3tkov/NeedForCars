using NeedForCars.Models.Contracts;
using NeedForCars.Models.Enums;
using NeedForCars.Models.Owned;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Models
{
    public class Model : IIdentifiable
    {
        public string Id { get; set; }

        [Required]
        public string MakeId { get; set; }
        public Make Make { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ModelEngines> ModelEngines { get; set; }

        //Nullables
        //Performance Data
        public int? TopSpeed { get; set; }

        public FuelConsumption FuelConsumption { get; set; }

        public Acceleration Acceleration { get; set; }

        public DriveWheel? DriveWheel { get; set; }

        public Transmission? Transmission { get; set; }

        [Range(1, 10)]
        public int? NumberOfGears { get; set; }

        //Production Data
        //TODO Validate production DateTimes in CarModel
        public DateTime? BeginningOfProduction { get; set; }

        public DateTime? EndOfProduction { get; set; }

        //Body/physical data
        public BodyType BodyType { get; set; }

        [Range(1, 8)]
        public int? Seats { get; set; }

        // TODO: Validations for wheel sizes: 
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
