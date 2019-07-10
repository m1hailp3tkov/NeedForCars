using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class EditMakeModel : DisplayMakeModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = "Make name can only contain Latin characters, spaces, dots or dashes")]
        public string Name { get; set; }

        [Display(Name = "New Logo")]
        public IFormFile NewLogo { get; set; }
    }
}
