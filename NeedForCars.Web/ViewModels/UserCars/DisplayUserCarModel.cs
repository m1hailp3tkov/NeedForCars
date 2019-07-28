using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.UserCars
{
    public class DisplayUserCarModel : IMapFrom<UserCar>
    {
        public int CarId { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        public int? CustomEngineId { get; set; }
    }
}
