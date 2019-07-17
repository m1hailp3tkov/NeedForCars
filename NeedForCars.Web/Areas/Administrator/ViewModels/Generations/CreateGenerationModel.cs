using NeedForCars.Models;
using NeedForCars.Models.Enums;
using NeedForCars.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class CreateGenerationModel : IMapTo<Generation>
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z0-9 ()-]+",ErrorMessage = "{0} can only contain Latin characters, brackets, dashes and spaces")]
        public string Name { get; set; }

        [Required]
        [EnumDataType(typeof(BodyType), ErrorMessage = "Invalid body type")]
        public BodyType BodyType { get; set; }

        public string Description { get; set; }
    }
}
