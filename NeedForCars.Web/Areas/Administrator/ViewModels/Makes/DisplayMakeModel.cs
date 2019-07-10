using NeedForCars.Web.Common;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class DisplayMakeModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get => $"/images/makes/{Id}.png"; }
    }
}
