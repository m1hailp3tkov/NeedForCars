using NeedForCars.Web.Areas.Administrator.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Data
{
    public class CarDetailsWithImagesModel : CarDetailsModel
    {
        public IEnumerable<string> ImageUrls { get; set; }
    }
}
