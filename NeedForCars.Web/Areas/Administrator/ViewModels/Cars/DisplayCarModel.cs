using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class DisplayCarModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public Engine Engine { get; set; }

        public DateTime BeginningOfProduction { get; set; }

        public DateTime EndOfProduction { get; set; }

        public string Name { get; set; }
    }
}
