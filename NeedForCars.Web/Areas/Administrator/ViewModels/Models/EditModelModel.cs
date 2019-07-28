using NeedForCars.Models;
using NeedForCars.Services.Mapping;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Models
{
    public class EditModelModel : CreateModelModel, IMapFrom<Model>
    {
        public int Id { get; set; }
    }
}
