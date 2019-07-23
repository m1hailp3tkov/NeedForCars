using Microsoft.AspNetCore.Http;
using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using NeedForCars.Web.Common;
using System.ComponentModel.DataAnnotations;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class EditMakeModel : DisplayMakeModel, IMapTo<Make>
    {
        [Required(ErrorMessage = GlobalConstants.REQUIRED_NAME)]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = GlobalConstants.MAKE_NAME_INVALID)]
        public new string Name { get; set; }

        [Display(Name = "New Logo")]
        public IFormFile NewLogo { get; set; }
    }
}
