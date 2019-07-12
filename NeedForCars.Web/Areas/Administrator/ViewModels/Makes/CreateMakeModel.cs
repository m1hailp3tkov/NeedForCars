using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Makes
{
    public class CreateMakeModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("[A-Za-z-. ]{2,}", ErrorMessage = "Make name can only contain Latin characters, spaces, dots and dashes")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "You must add a logo image")]
        public IFormFile Logo { get; set; }
    }
}
