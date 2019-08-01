using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Models
{
    public class DisplayModelModel : IMapFrom<Model>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
