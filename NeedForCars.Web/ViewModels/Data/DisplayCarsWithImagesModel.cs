using NeedForCars.Web.Areas.Administrator.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.ViewModels.Data
{
    public class DisplayCarsWithImagesModel : CarDetailsModel
    {
        public IEnumerable<string> ImageUrls { get; set; }

        public IEnumerable<DisplayCarWithEngineModel> Cars { get; set; }
    }
}
