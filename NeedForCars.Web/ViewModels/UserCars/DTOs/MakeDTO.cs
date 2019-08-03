using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.UserCars.DTOs
{
    public class MakeDTO : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
