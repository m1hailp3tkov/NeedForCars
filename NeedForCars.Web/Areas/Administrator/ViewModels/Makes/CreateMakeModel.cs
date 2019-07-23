using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class CreateMakeModel : IMapTo<Make>
    {
        [Required(ErrorMessage = GlobalConstants.REQUIRED_NAME)]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = GlobalConstants.MAKE_NAME_INVALID)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = GlobalConstants.MAKE_LOGO_REQUIRED)]
        public IFormFile Logo { get; set; }
    }
}
