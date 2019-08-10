using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Data
{
    public class DisplayCarWithEngineModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string EngineName { get; set; }

        public int EngineMaxHP { get; set; }

        public int BeginningOfProductionYear { get; set; }

        public int? EndOfProductionYear { get; set; }

        public Transmission Transmission { get; set; }

        public DriveWheel DriveWheel { get; set; }
    }
}
