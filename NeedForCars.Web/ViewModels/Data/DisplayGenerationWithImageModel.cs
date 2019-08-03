using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Data
{
    public class DisplayGenerationWithImageModel : IMapFrom<Generation>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BodyType BodyType { get; set; }

        public string ImageUrl { get; set; }

        public int ProductionYearBegin { get; set; }

        public int? ProductionYearEnd { get; set; }

        public int CarsCount { get; set; }
    }
}
