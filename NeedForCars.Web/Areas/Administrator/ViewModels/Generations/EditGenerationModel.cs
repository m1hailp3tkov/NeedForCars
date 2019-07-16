using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class EditGenerationModel : CreateGenerationModel, IMapFrom<Generation>
    {
        public string Id { get; set; }
    }
}
