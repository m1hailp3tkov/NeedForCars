using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class DisplayGenerationModel : IMapFrom<Generation>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public BodyType BodyType { get; set; }
    }
}
