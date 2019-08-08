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
        [RegularExpression(GlobalConstants.MAKE_NAME_REGEX, ErrorMessage = GlobalConstants.MAKE_NAME_INVALID)]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = GlobalConstants.MAKE_DESCRIPTION_TOO_LONG)]
        public string Description { get; set; }

        [Required(ErrorMessage = GlobalConstants.MAKE_LOGO_REQUIRED)]
        public IFormFile Logo { get; set; }
    }
}
