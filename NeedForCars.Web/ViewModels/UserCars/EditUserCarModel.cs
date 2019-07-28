using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.ViewModels.UserCars
{
    public class EditUserCarModel : CreateUserCarModel, IMapFrom<UserCar>
    {
        public string Id { get; set; }
    }
}
