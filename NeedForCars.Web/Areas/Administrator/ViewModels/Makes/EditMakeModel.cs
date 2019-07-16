using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class EditMakeModel : DisplayMakeModel, IMapTo<Make>
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = "Make name can only contain Latin characters, spaces, dots and dashes")]
        public new string Name { get; set; }

        [Display(Name = "New Logo")]
        public IFormFile NewLogo { get; set; }
    }
}
