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
        [Display(Name = "New Logo")]
        public IFormFile NewLogo { get; set; }
    }
}
