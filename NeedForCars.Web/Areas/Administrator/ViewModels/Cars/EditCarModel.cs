using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class EditCarModel : CreateCarModel, IMapFrom<Car>
    {
        public string Id { get; set; }
    }
}
