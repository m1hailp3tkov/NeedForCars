using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class CreateMakeModel : IMapTo<Make>
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = "Make name can only contain Latin characters, spaces, dots and dashes")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "You must add a logo image")]
        public IFormFile Logo { get; set; }
    }
}
