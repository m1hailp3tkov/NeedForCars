using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.UserCars.DTOs
{
    public class CarDTO : IMapFrom<Car>
    {
        public int Id { get; set; }

        public int GenerationId { get; set; }

        public string Name { get; set; }

        public string EngineName { get; set; }

        public int EngineMaxHP { get; set; }

        public string DisplayText { get => $"{this.EngineName} ({this.EngineMaxHP} HP) {this.Name}"; }
    }
}
