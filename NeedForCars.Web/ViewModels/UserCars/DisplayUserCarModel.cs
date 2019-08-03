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
        public string Id { get; set; }

        public int CarId { get; set; }

        public bool IsPublic { get; set; }

        public bool ForSale { get; set; }

        public int? Price { get; set; }

        public Currency? Currency { get; set; }

        public int? CustomEngineId { get; set; }

        public string ImageUrl { get => $"/images/usercars/{this.Id}/0.png"; }
    }
}
