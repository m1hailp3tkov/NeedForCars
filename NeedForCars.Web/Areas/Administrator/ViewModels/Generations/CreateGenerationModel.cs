using NeedForCars.Models;
using NeedForCars.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NeedForCars.Web.Areas.Administrator.ViewModels.Generations
{
    public class CreateGenerationModel : IMapTo<Generation>
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z0-9 ()-]+",ErrorMessage = "{0} can only contain Latin characters, brackets, dashes and spaces")]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
