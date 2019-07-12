using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Models
{
    public class CreateModelModel
    {
        [Required]
        [RegularExpression("[A-Za-z0-9-. ]+", ErrorMessage = "Model name can only contain Latin characters, numbers, spaces, dots and dashes")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
