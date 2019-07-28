using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Cars
{
    public class EditCarModel : CreateCarModel, IMapFrom<Car>, IMapTo<Car>
    {
        public int Id { get; set; }

        public int GenerationId { get; set; }
    }
}
