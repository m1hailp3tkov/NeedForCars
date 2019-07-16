using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Engines
{
    public class EditEngineModel : CreateEngineModel, IMapFrom<Engine>
    {
        public string Id { get; set; }
    }
}
