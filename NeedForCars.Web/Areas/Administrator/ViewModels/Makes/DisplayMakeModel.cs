using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class DisplayMakeModel : IMapFrom<Make>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get => $"/images/makes/{Id}.png"; }
    }
}
