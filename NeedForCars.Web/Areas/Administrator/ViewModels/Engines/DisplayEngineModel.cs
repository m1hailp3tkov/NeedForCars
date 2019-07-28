using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Engines
{
    public class DisplayEngineModel : IMapFrom<Engine>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MaxHP { get; set; }

        public FuelType FuelType { get; set; }

        public string Creator { get; set; }
    }
}
