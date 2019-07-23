using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Models
{
    public class CreateModelModel : IMapTo<Model>
    {
        [Required]
        [RegularExpression("[A-Za-z0-9-. ]+", ErrorMessage = GlobalConstants.MODEL_NAME_INVALID)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
